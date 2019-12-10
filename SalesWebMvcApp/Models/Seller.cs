using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvcApp.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public DateTime biirthDate { get; set; }
        public double baseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; }

        #region Contrutores
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime biirthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            this.email = email;
            this.biirthDate = biirthDate;
            this.baseSalary = baseSalary;
            Department = department;
        }
        #endregion

        #region Métodos Customizados
        public void AddSeler(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            //Filtrar as vendas de um vendedor em um intervalo de datas
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
        #endregion

    }
}
