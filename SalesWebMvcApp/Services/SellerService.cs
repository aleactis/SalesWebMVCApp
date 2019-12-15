using SalesWebMvcApp.Data;
using SalesWebMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
