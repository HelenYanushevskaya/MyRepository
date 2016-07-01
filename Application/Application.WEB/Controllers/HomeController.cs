using Application.BLL.DTO;
using Application.BLL.Services;
using Application.WEB.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Application.WEB.Controllers
{
    public class HomeController : Controller
    {
        MenuService menuService;
        public HomeController(MenuService serv)
        {
            menuService = serv;
        }
        public ActionResult Index()
        {
            Mapper.CreateMap<DishDTO, DishView>();
            var dish = Mapper.Map<IEnumerable<DishDTO>, List<DishView>>(menuService.GetDishes());
            return View(dish);
        }

        public ActionResult MakeMenu(int? id)
        {
            Mapper.CreateMap<MenuDTO, MenuView>()
                .ForMember("DishId", opt => opt.MapFrom(src => src.Id));
            var menu = Mapper.Map<DishDTO, MenuView>(menuService.GetDish(id));
            return View(menu);


        }
        [HttpPost]
        public ActionResult MakeMenu(MenuView menu)
        {

            Mapper.CreateMap<MenuView, MenuDTO>();
            var menuDto = Mapper.Map<MenuView, MenuDTO>(menu);
            menuService.MakeMenu(menuDto);

            return View(menu);
        }
        protected override void Dispose(bool disposing)
        {
            menuService.Dispose();
            base.Dispose(disposing);
        }
    }
}
/*   public class HomeController : Controller
   {
       IMenuService MenuService;


       public HomeController(IMenuService serv)
       {
           MenuService = serv;
       }
       public ActionResult Index()
       {
           Mapper.CreateMap<DishDTO, Dish>();
           var Dishs = Mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(MenuService.GetDishs());
           return View(Dishs);
       }

       public ActionResult MakeMenu(int? id)
       {
           try
           {
               Mapper.CreateMap<DishDTO, Menu>()
                   .ForMember("DishId", opt => opt.MapFrom(src => src.Id));
               var Menu = Mapper.Map<DishDTO, Menu>(MenuService.GetDish(id));
               return View(Menu);
           }
           catch (ValidationException ex)
           {
               return Content(ex.Message);
           }
       }
       [HttpPost]
       public ActionResult MakeMenu(Menu menu)
       {
           try
           {
               Mapper.CreateMap<Menu, MenuDTO>();
               var MenuDto = Mapper.Map<Menu, MenuDTO>(menu);
               MenuService.MakeMenu(MenuDto);
               return Content("<h2>Ваш заказ успешно оформлен</h2>");
           }
           catch (ValidationException ex)
           {
               ModelState.AddModelError(ex.Property, ex.Message);
           }
           return View(menu);
       }
       protected override void Dispose(bool disposing)
       {
           MenuService.Dispose();
           base.Dispose(disposing);
       }
   }
}
// GET: Home
/*       public ActionResult Index(string sortMenu)
      {
          ViewBag.DishSortParm = string.IsNullOrEmpty(sortMenu) ? "Dish desc" : "";
          ViewBag.OraganizationSortParm = string.IsNullOrEmpty(sortMenu) ? "Oraganization desc" : "";
          ViewBag.DateSortParm = sortMenu == "Date" ? "Date desc" : "Date";
          var elements = from e in db.Menus
                         select e;
          switch (sortMenu)
          {
              case "Dish desc":
                  elements = elements.MenuByDescending(e => e.Dish.Name);
                  break;
              case "Oraganization desc":
                  elements = elements.MenuByDescending(e => e.Organization.Name);
                  break;
              case "Date desc":
                  elements = elements.MenuByDescending(e => e.Date);
                  break;
              default:
                  elements = elements.MenuBy(e => e.Date);
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
}*/
