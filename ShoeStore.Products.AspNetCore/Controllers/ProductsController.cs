using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Products.Domain;

namespace ShoeStore.Products.AspNetCore.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        // GET api/values
        [HttpGet]
        [Authorize]
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product()
            {
                Id = 1,
                Name = "iPhone 9",
                Code = "iP8",
                Cost = 1000,
                ShortDescription = "iPhone 8 mobile phone",
                LongDescription = "iPhone 8 mobile phone is better",
                Rank = 1,
                Stock = 3
            });

            products.Add(new Product()
            {
                Id = 2,
                Name = "iPhone X",
                Code = "iPX",
                Cost = 2000,
                ShortDescription = "iPhone X mobile phone",
                LongDescription = "iPhone X mobile phone is better",
                Rank = 2,
                Stock = 5
            });

            products.Add(new Product()
            {
                Id = 2,
                Name = "iPhone 7",
                Code = "iP7",
                Cost = 2000,
                ShortDescription = "iPhone 7 mobile phone",
                LongDescription = "iPhone 7 mobile phone is better",
                Rank = 3,
                Stock = 8
            });

            return products;
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
