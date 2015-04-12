using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhilStore.DAL.Models;
using Microsoft.AspNet.Identity;
using PhilStore.DAL.Specifications;

namespace PhilStore.Controllers
{
    public class AdvertisementsController : Controller
    {

        private IAppDbContext _db;
        public AdvertisementsController(IAppDbContext db)
        {
            _db = db;
        }
                
        // GET: Advertisements
        public ActionResult Index()
        {
            return View(_db.Advertisements.ToList());
        }

        // GET: Advertisements/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = _db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // GET: Advertisements/Create
        public ActionResult Create()
        {
            string theUser = User.Identity.GetUserName();
            HttpCookie lastSearch = new HttpCookie("search", "humans");
            HttpContext.Response.SetCookie(lastSearch);
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title")] Advertisement advertisement)
        {
            //var existingSearch = HttpContext.Request.Cookies["search"];
            advertisement.CreateDate = DateTime.Now;
            advertisement.CreatedBy = User.Identity.GetUserName();

            if (ModelState.IsValid)
            {
                _db.Advertisements.Add(advertisement);
                _db.SaveChanges();
                return RedirectToAction("");
            }

            return View(advertisement);
        }

        // GET: Advertisements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = _db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,CreateDate")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(advertisement).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertisement);
        }

        // GET: Advertisements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = _db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisement advertisement = _db.Advertisements.Find(id);
            _db.Advertisements.Remove(advertisement);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
