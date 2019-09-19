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
        public List<Catalogue> GetAllCatalogues()
        {
            using (ProductsDbContext context = new ProductsDbContext())
            {
                List<Catalogue> Catalogues = context.Catalogues.ToList();
                return Catalogues;
            }
        }

        public Catalogue GetCatalogueById(int catalogueId)
        {
            using (ProductsDbContext context = new ProductsDbContext())
            {
                Catalogue foundCatalogue = context.Catalogues.Find(catalogueId);
                return foundCatalogue;
            }
        }

        public Catalogue AddCatalogue(Catalogue catalogue)
        {
            using (ProductsDbContext context = new ProductsDbContext())
            {
                Catalogue addedCatalogue = context.Catalogues.Add(catalogue).Entity;
                context.SaveChanges();
                return addedCatalogue;
            }
        }

        public Catalogue UpdateCatalogue(Catalogue catalogue)
        {
            using (ProductsDbContext context = new ProductsDbContext())
            {
                Catalogue updatedCatalogue = context.Catalogues.Find(catalogue.Id);
                context.Entry(updatedCatalogue).CurrentValues.SetValues(catalogue);
                context.SaveChanges();
                return updatedCatalogue;
            }
        }

        public void DeleteCatalogue(int id)
        {
            using (ProductsDbContext context = new ProductsDbContext())
            {
                Catalogue deletedCatalogue = context.Catalogues.Find(id);
                context.Catalogues.Remove(deletedCatalogue);
                context.SaveChanges();
            }
        }


        public CatalogueProduct AddProductToCatalogue(Catalogue catalogue, Product product)
        {
            using (ProductsDbContext context = new ProductsDbContext())
            {
                CatalogueProduct existingCatalogueProduct = context.CatalogueProducts
                    .Where(cp => cp.CatalogueId == catalogue.Id && cp.ProductId == product.Id)
                    .FirstOrDefault();
                if (existingCatalogueProduct == null)
                {
                    CatalogueProduct newCatalogueProduct = new CatalogueProduct();
                    newCatalogueProduct.ProductId = product.Id;
                    newCatalogueProduct.CatalogueId = catalogue.Id;
                    context.CatalogueProducts.Add(newCatalogueProduct);

                    context.SaveChanges();

                    return newCatalogueProduct;
                }

                return existingCatalogueProduct;
            }
        }

        public void DeleteProductFromCatalogue(Catalogue catalogue, Product product)
        {
            using (ProductsDbContext context = new ProductsDbContext())
            {
                var catalogueProducts = context.CatalogueProducts
                    .Where(cp => cp.ProductId == product.Id).ToArray();

                context.CatalogueProducts.RemoveRange(catalogueProducts);

                context.SaveChanges();
            }
        }
    }
}
