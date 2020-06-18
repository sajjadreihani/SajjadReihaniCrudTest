using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public class PaggingData<T>
    {
        public int TotalLength { get; set; }
        public IEnumerable<T> List { get; set; }
    }
}
