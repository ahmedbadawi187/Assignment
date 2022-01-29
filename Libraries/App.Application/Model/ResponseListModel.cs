using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Application.Model
{
    public class ResponseListModel<T>
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
