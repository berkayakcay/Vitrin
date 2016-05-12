using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShowCase.Models;
using PagedList;

namespace OnlineShowCase.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {

        public ActionResult AddNewUser()
        {
            var item = new User();

            return PartialView("_AddNewUserDialog",item);
        }

        [HttpPost]
        public ActionResult AddNewUser(User model)
        {
            if (ModelState.IsValid)
            {
                Entity.Users.Add(model);
                Entity.SaveChanges();
                Success("#Successful! it has been created!", true);
                return RedirectToAction("Index");
            }

            Warning("#Failed! it has not been created!", true);

            return RedirectToAction("Index");
        }

        // GET: Index
        public ActionResult Index(int? page)
        {
            var items = Entity.Users;

            if (items == null)
            {
                return HttpNotFound();
            }

            return View(items.ToList().ToPagedList(page ?? 1, 5));
        }



        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                Entity.Users.Add(model);
                Entity.SaveChanges();
                Success("#Successful! it has been created!", true);
                return RedirectToAction("Index");
            }

            Warning("#Failed! it has not been created!", true);

            return View();
        }




        // GET: Detail
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = Entity.Users.Find(id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }


        // GET: Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = Entity.Users.Find(id);

            if (item == null)
            {
                HttpNotFound();
            }

            return View(item);
        }



        // POST: Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User model)
        {
            if (ModelState.IsValid)
            {
                Entity.Entry(model).State = EntityState.Modified;
                Entity.SaveChanges();
                Success("Successful! it has been changed!", true);
                return RedirectToAction("Index");
            }
            return View(model);
        }



        // GET: Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = Entity.Users.Find(id);

            if (item == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Danger("#Warning! it will be deleted permanently!");

            return View(item);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var onDelete = Entity.Users.FirstOrDefault(x => x.Id == id);
                Entity.Users.Remove(onDelete);
                Entity.SaveChanges();
                Success("Successful! it has been changed!", true);
                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
