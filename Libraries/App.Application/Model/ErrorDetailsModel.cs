using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Application.Model
{
    public class ErrorDetailsModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
