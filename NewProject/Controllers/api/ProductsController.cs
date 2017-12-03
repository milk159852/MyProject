using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NewProject.Models;

namespace NewProject.Controllers.api
{
    public class ProductsController : ApiController
    {
        private Northwind _context;

        public ProductsController()
        {
            _context = new Northwind();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        // GET: api/Products
        public IEnumerable<Products> GetProducts()
        {
            var result = _context.Products.ToList();
            return result;
        }

        // GET: api/Products/5
        public IHttpActionResult GetProducts(int id)
        {
            var result = _context.Products.SingleOrDefault(c => c.ProductID == id);
            
            if (result == null)
                return NotFound();

            return Ok();
        }


        // POST: api/Products
        [HttpPost]
        public IHttpActionResult CreateProducts(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Products.Add(products);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = products.ProductID }, products);
        }

        // PUT: api/Products/5
        [HttpPut]
        public IHttpActionResult UpdateProducts(int id, Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _context.Products.SingleOrDefault(c => c.ProductID == id);

            if (result == null)
                return NotFound();

            //result.ProductName = products.ProductName;
            //update parameter

            _context.SaveChanges();
            return Ok();
        }



        // DELETE: api/Products/5
        [HttpDelete]
        public IHttpActionResult DeleteProducts(int id)
        {
            var result = _context.Products.SingleOrDefault(c => c.ProductID == id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Products.Remove(result);
            _context.SaveChanges();

            return Ok();
        }


    }
}