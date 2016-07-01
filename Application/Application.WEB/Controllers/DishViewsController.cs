using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Application.WEB.ViewModels;

namespace Application.WEB.Controllers
{
    public class DishViewsController : Controller
    {
       /* private AppContext db = new AppContext();

        // GET: DishViews
        public ActionResult Index()
        {
            return View(db.Dishes.ToList());
        }

        // GET: DishViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DishView dishView = db.Dishes.Find(id);
            if (dishView == null)
            {
                return HttpNotFound();
            }
            return View(dishView);
        }

        // GET: DishViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DishViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Ingredients,Weight")] DishView dishView)
        {
            if (ModelState.IsValid)
            {
                db.Dishes.Add(dishView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dishView);
        }

        // GET: DishViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DishView dishView = db.Dishes.Find(id);
            if (dishView == null)
            {
                return HttpNotFound();
            }
            return View(dishView);
        }

        // POST: DishViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Ingredients,Weight")] DishView dishView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dishView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dishView);
        }

        // GET: DishViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DishView dishView = db.Dishes.Find(id);
            if (dishView == null)
            {
                return HttpNotFound();
            }
            return View(dishView);
        }

        // POST: DishViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DishView dishView = db.Dishes.Find(id);
            db.Dishes.Remove(dishView);
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
        }*/
    }
}
