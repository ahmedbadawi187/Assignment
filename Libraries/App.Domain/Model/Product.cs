using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Domain.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int QuantityPerUnitId { get; set; }
        public int ReorderLevel { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool IsPublish { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Unit QuantityPerUnit { get; set; }
        public virtual Supplier Supplier { get; set; }

    }
}
