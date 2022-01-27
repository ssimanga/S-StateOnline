using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S_StateOnline.Core.Models;
using S_StateOnline.DataAccess.Inmemory;

namespace S_StateOnline.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository context;
        public CategoryController()
        {
            context = new CategoryRepository();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<ProductCategory> categories = context.Collection().ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            ProductCategory category = new ProductCategory();
            return View(category);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                context.Insert(category);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory category = context.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(category);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory category, string Id)
        {
            ProductCategory cat = context.Find(Id);
            if (cat == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                cat.Category = category.Category;
    
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory categoryToDelete = context.Find(Id);
            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory categoryToDelete = context.Find(Id);
            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}