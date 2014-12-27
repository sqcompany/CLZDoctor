using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLZDoctor.Entities
{
    public class PageDataModel<T>
    {
        public int TotalCount { get; set; }
        public List<T> Rows { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
