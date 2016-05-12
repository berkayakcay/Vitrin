using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using OnlineShowCase.Models;

namespace OnlineShowCase.Controllers
{
    [Authorize]
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index(int? id )
        {
            if (id == null)
            {
                var maincategories = Entity.Categories.Where(x => x.SubCategoryId == null);
                return View(maincategories);
            }
            var categories = Entity.Categories.Where(x => x.SubCategoryId == id);
            if (!categories.Any())
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        public ActionResult List(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Index", "Category");
            }

            var items = Entity.Items.Where(x => x.CategoryId == id);
            if (!items.Any())
            {
                return HttpNotFound();
            }

            return View(items);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Entity.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}