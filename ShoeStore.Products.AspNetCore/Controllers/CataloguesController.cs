using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoeStore.Products.Domain;
using ShoeStore.Products.Tasks;

namespace ShoeStore.Products.AspNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/v1")]
    public class CatalguesController : Controller
    {
        [Route("catalogues")]
        [HttpGet]
        public IEnumerable<Catalogue> GetCatalogues()
        {
            CatalogueTasks tasks = new CatalogueTasks();
            List<Catalogue> catalogues = tasks.GetAllCatalogues();

            return catalogues;
        }

        [Route("catalogues/{id}")]
        public Catalogue GetCatalogue(int id)
        {
            CatalogueTasks tasks = new CatalogueTasks();
            Catalogue product = tasks.GetCatalogueById(id);

            return product;
        }

        [Route("catalogues")]
        public Catalogue Post([FromBody]Catalogue catalogue)
        {
            CatalogueTasks tasks = new CatalogueTasks();
            Catalogue addedCatalogue = tasks.AddCatalogue(catalogue);

            return addedCatalogue;
        }

        [Route("catalogues")]
        public Catalogue Put(int id, [FromBody]Catalogue catalogue)
        {
            CatalogueTasks tasks = new CatalogueTasks();
            Catalogue updatedCatalogue = tasks.UpdateCatalogue(catalogue);

            return updatedCatalogue;
        }

        [Route("catalogues")]
        public void Delete(int id)
        {
            CatalogueTasks tasks = new CatalogueTasks();
            tasks.DeleteCatalogue(id);
        }
    }
}