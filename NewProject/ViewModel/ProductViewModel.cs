using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProject.ViewModel
{
    public class ProductViewModel
    {
        public Products Product { get; set; }
        public IEnumerable<Suppliers> Suppliers { get; set; }
        public IEnumerable<Categories> Categories { get; set; }

    }
}