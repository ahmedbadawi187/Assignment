using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Domain.Model
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public bool IsPublish { get; set; }
        public bool IsDeleted { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}
