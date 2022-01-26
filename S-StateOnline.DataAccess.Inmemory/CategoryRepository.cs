using S_StateOnline.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace S_StateOnline.DataAccess.Inmemory
{
    class CategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> categories;
        public CategoryRepository()
        {
            categories = cache["categories"] as List<ProductCategory>;
            if (categories == null)
            {
                categories = new List<ProductCategory>();
            }

        }
        public void Commit()
        {
            cache["categories"] = categories;
        }

        public void Insert(ProductCategory c)
        {
            categories.Add(c);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory categoryToUpdate = categories.Find(c => c.Id == productCategory.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = categories.Find(p => p.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return categories.AsQueryable();
        }
        public void Delete(string Id)
        {
            ProductCategory categoryToDelete = categories.Find(p => p.Id == Id);
            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
            }
            else
            {
                throw new Exception("Product not Found");
            }
        }
    }
}
