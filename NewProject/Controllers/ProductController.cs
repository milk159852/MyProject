using NewProject.Models;
using NewProject.ViewModel;
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
            var result = _context.Products
                .Include(c => c.Categories)
                .Include(c => c.Suppliers)
                .ToList();
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

        public ActionResult NewProduct()
        {
            var categories = _context.Categories.ToList();
            var suppliers = _context.Suppliers.ToList();

            var result = new ProductViewModel
            {
                Product = new Products(),
                Categories = categories,
                Suppliers = suppliers
            };
            return View("NewProduct", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Products product)
        {
            if (!ModelState.IsValid)
            {
                var result = new ProductViewModel
                {   
                    Product = product,
                    Categories = _context.Categories.ToList(),
                    Suppliers = _context.Suppliers.ToList()
                };

                return View("NewProduct", result);
            }

            if (product.ProductID == 0)
                _context.Products.Add(product);

            else
            {
                var result = _context.Products
                    .SingleOrDefault(c => c.ProductID == product.ProductID);

                result.ProductName = product.ProductName;
                result.SupplierID = product.SupplierID;
                result.CategoryID = product.CategoryID;
                result.QuantityPerUnit = product.QuantityPerUnit;
                result.UnitPrice = product.UnitPrice;
                result.UnitsInStock = product.UnitsInStock;
                result.UnitsOnOrder = product.UnitsOnOrder;
                result.ReorderLevel = product.ReorderLevel;
                result.Discontinued = product.Discontinued;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", product);
        }
    }
}