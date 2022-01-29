using BlazorShared.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorShared.Model
{
    public class SupplierModel : BaseModel
    {
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }
        public bool IsPublish { get; set; }
    }
}
