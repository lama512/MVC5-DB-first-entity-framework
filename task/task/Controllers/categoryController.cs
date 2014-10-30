using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task.Controllers
{
    [Authorize(Roles = "Admin")]
    public class categoryController : Controller
    {
        DataEntry db = new DataEntry();
        public ActionResult Index()
        {
            return View(db.categories.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(category category)
        {
            if (ModelState.IsValid)
            {
                db.categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);

        }
    }
}