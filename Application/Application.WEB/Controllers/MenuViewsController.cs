using System.Web.Mvc;

namespace Application.WEB.Controllers
{
    public class MenuViewsController : Controller
    {
       /* private AppContext db = new AppContext();

        // GET: MenuViews
        public ActionResult Index()
        {
            return View(db.Menus.ToList());
        }

        // GET: MenuViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuView menuView = db.Menus.Find(id);
            if (menuView == null)
            {
                return HttpNotFound();
            }
            return View(menuView);
        }

        // GET: MenuViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,DishId")] MenuView menuView)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menuView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuView);
        }

        // GET: MenuViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuView menuView = db.Menus.Find(id);
            if (menuView == null)
            {
                return HttpNotFound();
            }
            return View(menuView);
        }

        // POST: MenuViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,DishId")] MenuView menuView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuView);
        }

        // GET: MenuViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuView menuView = db.Menus.Find(id);
            if (menuView == null)
            {
                return HttpNotFound();
            }
            return View(menuView);
        }

        // POST: MenuViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuView menuView = db.Menus.Find(id);
            db.Menus.Remove(menuView);
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
