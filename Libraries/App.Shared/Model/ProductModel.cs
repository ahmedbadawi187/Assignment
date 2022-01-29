using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorShared.Model
{
    public class ProductModel : BaseModel
    {
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }
        [Range(1,int.MaxValue,ErrorMessage = "Field is required")]
        public int QuantityPerUnitId { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int ReorderLevel { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Field is required")]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int UnitsInStock { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public int UnitsOnOrder { get; set; }
        public bool IsPublish { get; set; }
        
    }
}
