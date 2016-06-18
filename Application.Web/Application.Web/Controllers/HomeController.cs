using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace Application.Web.Controllers
{
    public class HomeController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Home
        public ActionResult Index(string sortOrder)
        {
            ViewBag.DishSortParm = string.IsNullOrEmpty(sortOrder) ? "Dish desc" : "";
            ViewBag.OraganizationSortParm = string.IsNullOrEmpty(sortOrder) ? "Oraganization desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            var elements = from e in db.Menus
                           select e;
            switch (sortOrder)
            {
                case "Dish desc":
                    elements = elements.OrderByDescending(e => e.Dish.Name);
                    break;
                case "Oraganization desc":
                    elements = elements.OrderByDescending(e => e.Organization.Name);
                    break;
                case "Date desc":
                    elements = elements.OrderByDescending(e => e.Date);
                    break;
                default:
                    elements = elements.OrderBy(e => e.Date);
                    break;
            }
            return View(elements.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.DishId = new SelectList(db.Dishes, "Id", "Name");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,OrganizationId,DishId")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DishId = new SelectList(db.Dishes, "Id", "Name", menu.DishId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", menu.OrganizationId);
            return View(menu);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.DishId = new SelectList(db.Dishes, "Id", "Name", menu.DishId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", menu.OrganizationId);
            return View(menu);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,OrganizationId,DishId")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DishId = new SelectList(db.Dishes, "Id", "Name", menu.DishId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", menu.OrganizationId);
            return View(menu);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
