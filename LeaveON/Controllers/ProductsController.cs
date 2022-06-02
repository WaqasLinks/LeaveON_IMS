using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MYBUSINESS.CustomClasses;
using MYBUSINESS.Models;

namespace MYBUSINESS.Controllers
{
    public class ProductsController : Controller
    {
        private BusinessContext db = new BusinessContext();
        //[ChildActionOnly]
        public ActionResult DangerLowProducts()
        {
            int lowStock = db.Products.Where(x => x.Stock < 1).Count();
            //return PartialView("_DangerLowProducts", stock);
            return Json(new { data = lowStock}, JsonRequestBehavior.AllowGet);
        }
        // GET: Products
        public ActionResult Index()
        {
            ViewBag.Suppliers = db.Suppliers;
            return View(db.Products.ToList());
        }

        public ActionResult SearchData(string suppId)
        {
            if (suppId.Trim() == string.Empty)
            {

                return PartialView("_SelectedProducts", db.Products.OrderBy(i => i.Id).ToList());

            }
            else
            {
                int intSuppId = Int32.Parse(suppId.Trim());

                IQueryable<Product> selectedProducts = null;
                //selectedProducts = db.Products.Where(p => p.SupplierId == intSuppId);
                return PartialView("_SelectedProducts", selectedProducts.OrderBy(i => i.Id).ToList());

            }

        }

      
        public ActionResult Create()
        {
            //int maxId = db.Products.Max(p => p.Id);
            decimal maxId = db.Products.DefaultIfEmpty().Max(p => p == null ? 0 : p.Id);
            maxId += 1;
            ViewBag.SuggestedId = maxId;
            ViewBag.Suppliers = db.Suppliers;
            Product prod = new Product();

            prod.PurchasePrice = 0;
            prod.SalePrice = 0;
            prod.Stock = 0;

            prod.Saleable = true;
            return View(prod);
        }
        
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,PurchasePrice,SalePrice,Stock,Saleable,PerPack,IsService,ShowIn,BarCode,Serialize,BulkInfo,Track,Tax,SerialVin,Type,Category,Brand,ModelNumber,LocationInfo,Weight,Width,Height,OwnersCode,RentalsCode,DateOfPurchase,MonthlyPayment,InsuranceInfo,Notes")] Product product)
        {
            if (product.Stock == null)
            {
                product.Stock = 0;
            }

            if (product.PerPack == null || product.PerPack == 0)
            {
                product.PerPack = 1;
            }

            //if(product.IsService==true)
            //{
                //product.PurchasePrice = 0;
                //product.Stock = 0;
            //}
            //else
            //{
                product.Stock = product.Stock * product.PerPack;
            //}
            product.RackPosition = ProductColor.AssignColor(product.Stock);


            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Suppliers = db.Suppliers;
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            product.Stock = product.Stock / product.PerPack;
            //ViewBag.SuppName = product.Supplier.Name;
            if (product == null)
            {
                return HttpNotFound();
            }
            List<TextValuePair> myUnitTypeOptionList = new List<TextValuePair> {
                            new TextValuePair {
                                Text = "Product",
                                Value = "false"
                            },
                            new TextValuePair {
                                Text = "Service",
                                Value = "true"
                            }
                        };
            ViewBag.UnitTypeOptionList = myUnitTypeOptionList;
            return View(product);
        }
        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,PurchasePrice,SalePrice,Stock,Saleable,PerPack,IsService,ShowIn,BarCode,Serialize,BulkInfo,Track,Tax,SerialVin,Type,Category,Brand,ModelNumber,LocationInfo,Weight,Width,Height,OwnersCode,RentalsCode,DateOfPurchase,MonthlyPayment,InsuranceInfo,Notes")] Product product)
        {
            //Product prd = db.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            //product.SuppId = prd.SuppId;
            if (product.Stock == null)
            {
                product.Stock = 0;
            }

            if (product.PerPack == null || product.PerPack == 0)
            {
                product.PerPack = 1;
            }
            
                product.Stock = product.Stock * product.PerPack;
            
                product.RackPosition= ProductColor.AssignColor(product.Stock);
            
            if (ModelState.IsValid)
            {

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult CreateService()
        {
            //int maxId = db.Products.Max(p => p.Id);
            decimal maxId = db.Products.DefaultIfEmpty().Max(p => p == null ? 0 : p.Id);
            maxId += 1;
            ViewBag.SuggestedId = maxId;
            ViewBag.Suppliers = db.Suppliers;
            Product prod = new Product();

            prod.PurchasePrice = 0;
            prod.SalePrice = 0;
            prod.Stock = 0;

            prod.Saleable = true;
            return View(prod);
        }

        public ActionResult EditService(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            product.Stock = product.Stock / product.PerPack;
            //ViewBag.SuppName = product.Supplier.Name;
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //// GET: Products/Delete/5
        //public ActionResult Delete(decimal id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(decimal id)
        //{
        //    Product product = db.Products.Find(id);
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
