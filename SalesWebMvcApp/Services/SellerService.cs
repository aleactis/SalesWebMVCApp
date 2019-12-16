using SalesWebMvcApp.Data;
using SalesWebMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcApp.Services.Exceptions;

namespace SalesWebMvcApp.Services
{
    public class SellerService
    {
        //Criar uma dependência para o nosso DBContext
        private readonly SalesWebMvcAppContext _context;

        //Criar um construtor da classe para que a injeção de dependência possa ocorrer
        public SellerService(SalesWebMvcAppContext context)
        {
            _context = context;
        }

        //Implementar o método FindAll() retornando um List<Seller> na classe SellerService 
        //com todos os vendedores (operação síncrona)
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller objeto)
        {
            if (objeto is null)
            {
                throw new ArgumentNullException(nameof(objeto));
            }

            _context.Add(objeto);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            //Verificar primeiro se o registro não existe
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }

            //Interceptando uma excessão do nivel de acesso a dados e relançando essa excessão
            //e usando a excessão que criamos a nível de serviços. Isso é importante para segregar
            //as camadas. A nossa camada de serviço não irá propagar uma excessão do nível de acesso
            //a dados.Se uma excessão do nível de acesso a dados acontecer, a nossa camada de serviço
            //lançará uma excessão da camada dela! Então o nosso controlador (SellersController) lidará
            //apenas com excessões da camada dele (Serviços). Mostrar a arquitetura do diagrama da aula 1
            try
            {
                //Caso ele exista, atualiza!
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
