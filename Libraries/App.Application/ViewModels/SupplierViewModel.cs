using Assignment.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Application.ViewModels
{
    public class SupplierViewModel : BaseModel
    {
        public string Name { get; set; }
        public int TotalProducts { get; set; }
        public bool IsPublish { get; set; }
        
    }
}
