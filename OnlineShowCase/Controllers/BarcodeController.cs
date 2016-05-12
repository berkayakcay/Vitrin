using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShowCase.Repository;
using OnlineShowCase.Models;
using OnlineShowCase.ViewModels;
using PagedList;
using PagedList.Mvc;


namespace OnlineShowCase.Controllers
{
    [Authorize]
    public class BarcodeController : BaseController
    {
        // GET: Barcode
        public ActionResult Index(int? page)
        {
            var items = Entity.Items;
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items.ToList().ToPagedList(page ?? 1, 5));
        }



        // GET: Detail
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int[] itemvariantIds = Entity.ItemVariants.Where(x => x.ItemId == id).Select(s => s.Id).ToArray();

            var barcodes = from barcode in Entity.Barcodes
                           where itemvariantIds.Contains(barcode.Id)
                           select barcode;

            if (!barcodes.Any())
            {
                return HttpNotFound();
            }

            return View(barcodes.ToList());
        }



        // GET: Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            

            int[] itemvariantIds = Entity.ItemVariants.Where(x => x.ItemId == id).Select(s => s.Id).ToArray();

            var barcodes = from barcode in Entity.Barcodes
                           where itemvariantIds.Contains(barcode.Id)
                           select barcode;

            var variants = new VariantViewModel();

            variants.Item = Entity.Items.Find(id);
            variants.ItemVariants = Entity.ItemVariants.Where(x => x.ItemId == id).ToList();
            variants.Barcodes = barcodes.ToList();

            if (!barcodes.Any())
            {
                HttpNotFound();
            }

            return View(variants);
        }



        // POST: Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VariantViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var barcode in model.Barcodes)
                {
                    Entity.Entry(barcode).State = EntityState.Modified;
                    Entity.SaveChanges();
                }
                
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

            var item = Entity.Brands.Find(id);

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
                var onDelete = Entity.Brands.FirstOrDefault(x => x.Id == id);
                Entity.Brands.Remove(onDelete);
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