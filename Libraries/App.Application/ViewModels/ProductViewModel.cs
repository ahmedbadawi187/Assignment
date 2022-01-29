using Assignment.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Application.ViewModels
{
    public class ProductViewModel : BaseModel
    {
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsOnOrder { get; set; }
        public int UnitsInStock { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsPublish { get; set; }
    }
}
