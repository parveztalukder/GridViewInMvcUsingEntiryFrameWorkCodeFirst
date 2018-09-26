using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowDataInGridViewInMvc.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Basic { get; set; }
        public double Medical { get; set; }
        public double Travel { get; set; }
        public double Provident { get; set; }
        public double Tax { get; set; }
        public double GrossSalary { get; set; }
        public double Deduction { get; set; }
        public double NetSalary { get; set; }

        public double grossSal()
        {
            return Basic + medical() + travel();
        }
        public double totaldeduc()
        {
            return tax() + provident();
        }
        public double netsal()
        {
            return grossSal() - totaldeduc();
        }
        public double medical()
        {
            return Basic * .10;
        }
        public double travel()
        {
            return Basic * .10;
        }
        public double provident()
        {
            return Basic * .10;
        }
        public double tax()
        {
            return Basic * .05;
        }
      
    }
}