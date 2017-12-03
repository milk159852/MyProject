using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class ProductController : Controller
    {
        private Northwind _context;

        public ProductController()
        {
            _context = new Northwind();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Product
        public ActionResult Index()
        {
            var result = _context.Products.ToList();
            return View(result);
        }

        public ActionResult Detail(int id)
        {
            var result = _context.Products
                .Include(c => c.Categories)
                .Include(c => c.Suppliers)
                .SingleOrDefault(c => c.ProductID == id);
            return View(result);
        }
    }
}