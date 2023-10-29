using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_Assignment_3.Models
{
    public class MainVM
    {
        public IPagedList<authors> Authors { get; set; }
        
        public IPagedList<types> Types { get; set; }

        public IPagedList<borrows> Borrows { get; set; }
    }
}