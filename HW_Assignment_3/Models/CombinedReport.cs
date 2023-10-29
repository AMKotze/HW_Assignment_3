using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_Assignment_3.Models
{
    public class CombinedReport
    {
        //public PopularTypeVM PopularTypes { get; set; }
        //public StudentPointsVM StudentPoints { get; set; }

        public List<string> StudentNames { get; set; }
        public List<int> Points { get; set; }
        public List<string> StudentSurnames { get; set; }
        public List<string> StudentClasses { get; set; }

        public List<string> TypeNames { get; set; }
        public List<int> BorrowCounts { get; set; }
    }
}