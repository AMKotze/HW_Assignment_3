using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_Assignment_3.Models
{
    public class HomeVM
    {
        public IPagedList<students> Students { get; set; }

        public IPagedList<books> Books { get; set; }

        

       
    }
}