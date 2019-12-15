using SalesWebMvcApp.Data;
using SalesWebMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcApp.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcAppContext _context;

        //Criar um construtor da classe para que a injeção de dependência possa ocorrer
        public DepartmentService(SalesWebMvcAppContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}