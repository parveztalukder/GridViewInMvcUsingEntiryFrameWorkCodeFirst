using ShowDataInGridViewInMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowDataInGridViewInMvc.ViewModel
{
    public class EmployeeViewModel
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
    }
}