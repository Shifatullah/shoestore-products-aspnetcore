using ShoeStore.Products.Domain;
using ShoeStore.Products.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore.Products.Tasks
{
    public class CatalogueTasks
    {
        ProductsDbContext _context;

        public CatalogueTasks(ProductsDbContext context)
        {
            _context = context;
        }

        public List<Catalogue> GetAllCatalogues()
        {
            //using (ProductsDbContext context = new ProductsDbContext())
            //{
                List<Catalogue> Catalogues = _context.Catalogues.ToList();
                return Catalogues;
            //}
        }

        public Catalogue GetCatalogueById(int catalogueId)
        {
            //using (ProductsDbContext context = new ProductsDbContext())
            //{
                Catalogue foundCatalogue = _context.Catalogues.Find(catalogueId);
                return foundCatalogue;
            //}
        }

        public Catalogue AddCatalogue(Catalogue catalogue)
        {
            //using (ProductsDbContext context = new ProductsDbContext())
            {
                Catalogue addedCatalogue = _context.Catalogues.Add(catalogue).Entity;
                _context.SaveChanges();
                return addedCatalogue;
            }
        }

        public Catalogue UpdateCatalogue(Catalogue catalogue)
        {
            //using (ProductsDbContext context = new ProductsDbContext())
            {
                Catalogue updatedCatalogue = _context.Catalogues.Find(catalogue.Id);
                _context.Entry(updatedCatalogue).CurrentValues.SetValues(catalogue);
                _context.SaveChanges();
                return updatedCatalogue;
            }
        }

        public void DeleteCatalogue(int id)
        {
            //using (ProductsDbContext context = new ProductsDbContext())
            {
                Catalogue deletedCatalogue = _context.Catalogues.Find(id);
                _context.Catalogues.Remove(deletedCatalogue);
                _context.SaveChanges();
            }
        }


        public CatalogueProduct AddProductToCatalogue(Catalogue catalogue, Product product)
        {
            //using (ProductsDbContext context = new ProductsDbContext())
            {
                CatalogueProduct existingCatalogueProduct = _context.CatalogueProducts
                    .Where(cp => cp.CatalogueId == catalogue.Id && cp.ProductId == product.Id)
                    .FirstOrDefault();
                if (existingCatalogueProduct == null)
                {
                    CatalogueProduct newCatalogueProduct = new CatalogueProduct();
                    newCatalogueProduct.ProductId = product.Id;
                    newCatalogueProduct.CatalogueId = catalogue.Id;
                    _context.CatalogueProducts.Add(newCatalogueProduct);

                    _context.SaveChanges();

                    return newCatalogueProduct;
                }

                return existingCatalogueProduct;
            }
        }

        public void DeleteProductFromCatalogue(Catalogue catalogue, Product product)
        {
            //using (ProductsDbContext context = new ProductsDbContext())
            {
                var catalogueProducts = _context.CatalogueProducts
                    .Where(cp => cp.ProductId == product.Id).ToArray();

                _context.CatalogueProducts.RemoveRange(catalogueProducts);

                _context.SaveChanges();
            }
        }
    }
}
