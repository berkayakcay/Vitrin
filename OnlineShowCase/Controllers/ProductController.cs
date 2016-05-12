using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShowCase.Models;

namespace OnlineShowCase.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        // GET: Item
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Category");
            }
            Item item = Entity.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
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