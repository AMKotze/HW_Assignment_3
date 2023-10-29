using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_Assignment_3.Models
{
    public class PopularTypeVM
    {
        public List<string> TypeNames { get; set; }
        public List<int> BorrowCounts { get; set; }
    }
}