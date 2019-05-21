using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.Models.ViewModels
{
    public class ProductVM
    {
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ProductCatagoryName { get; set; }
    }
}