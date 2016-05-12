using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShowCase.Models;
using OnlineShowCase.Repository;
using PagedList;
using PagedList.Mvc;

namespace OnlineShowCase.Controllers
{
    [Authorize]
    public class ItemController : BaseController
    {
        // GET: Item
        public ActionResult Index(int? page)
        {
            var items = Entity.Items;
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items.ToList().ToPagedList(page ?? 1, 5));
        }



        // GET: Create
        public ActionResult Create()
        {
            ViewBag.subcats = new SelectList(Entity.Categories.Where(x => x.SubCategoryId != null), "Id", "Name");
            ViewBag.brands = new SelectList(Entity.Brands, "Id", "Name");

            List<ItemColor> itemcolors = Entity.ItemColors.ToList();
            ViewBag.itemcolors = itemcolors;

            List<ItemDim> itemdims = Entity.ItemDims.ToList();
            ViewBag.itemdims = itemdims;

            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item, FormCollection form)
        {
            item.CategoryId = int.Parse(Request.Form["subcats"]);
            item.BrandId = int.Parse(Request.Form["brands"]);

            List<int> colorIds = Request.Form["colors"].Split(',').Select(int.Parse).ToList();
            List<int> dimIds = Request.Form["dims"].Split(',').Select(int.Parse).ToList();

            if (ModelState.IsValid)
            {
                Entity.Items.Add(item);
                Entity.SaveChanges();
                List<ItemVariant> itemVariants = new List<ItemVariant>();
                foreach (var colorId in colorIds)
                {
                    foreach (var dimId in dimIds)
                    {
                        itemVariants.Add(new ItemVariant
                        {
                            ItemId = item.Id,
                            ItemColorId = colorId,
                            ItemDimId = dimId
                        });
                    }
                }
                Entity.ItemVariants.AddRange(itemVariants);
                Entity.SaveChanges();

                List<Barcode> barcodes = new List<Barcode>();
                foreach (var variant in itemVariants)
                {
                    barcodes.Add(new Barcode
                    {
                        BarcodeTypeId = 1,
                        ItemVariantId = variant.Id,
                        ItemBarcode = "0000000000"
                    });
                }
                Entity.Barcodes.AddRange(barcodes);
                Entity.SaveChanges();
                Success("#Successful! it has been created!", true);
                return RedirectToAction("Index", "Item");
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
            Item item = Entity.Items.Find(id);
            if (item == null)
                return HttpNotFound();

            return View(item);
        }


        
        // GET: Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = Entity.Items.Find(id);

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
            var onDelete = Entity.Items.Find(id);
                Entity.Items.Remove(onDelete);
                Entity.SaveChanges();
                Success("Successful! it has been changed!", true);
                return RedirectToAction("Index");
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