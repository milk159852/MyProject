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
using AutoMapper;
using NewProject.Dto;

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
        public IEnumerable<ProductsDto> GetProducts()
        {
            return _context.Products.ToList().Select(Mapper.Map<Products,ProductsDto>);
        }

        // GET: api/Products/5
        public IHttpActionResult GetProducts(int id)
        {
            var result = _context.Products.SingleOrDefault(c => c.ProductID == id);
            
            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<Products,ProductsDto>(result));
        }


        // POST: api/Products
        [HttpPost]
        public IHttpActionResult CreateProducts(ProductsDto products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = Mapper.Map<ProductsDto, Products>(products);
            _context.Products.Add(result);
            _context.SaveChanges();

            products.ProductID = products.ProductID;

            return Created(new Uri(Request.RequestUri+"/"+products.ProductID), products);
        }

        // PUT: api/Products/5
        [HttpPut]
        public IHttpActionResult UpdateProducts(int id, ProductsDto products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _context.Products.SingleOrDefault(c => c.ProductID == id);

            if (result == null)
                return NotFound();
            Mapper.Map<ProductsDto, Products>(products, result);
            //result.ProductName = products.ProductName;
            //update parameter

            _context.SaveChanges();
            return Ok();
        }



        // DELETE: api/Products/5
        [HttpDelete]
        public IHttpActionResult DeleteProducts(int id)
        {
            var result = _context.Products.SingleOrDefault(c => c.ProductID == id );
           

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