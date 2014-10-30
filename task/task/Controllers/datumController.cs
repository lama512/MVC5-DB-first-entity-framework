using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace task.Controllers
{
    public class datumController : Controller
    {
        DataEntry db = new DataEntry();
        public ActionResult Index()
        {
            var data = from p in db.categories

                       select p.categoryName;

            SelectList list = new SelectList(data);
            ViewBag.Roles = list;
            return View();
        }
        public ActionResult create ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            string category = Request.Form["category"];

            if (file != null)
            {
                
               string ImageName = System.IO.Path.GetFileName(file.FileName);
               // string physicalPath = Server.MapPath("~/images/" + ImageName);
              //  string physicalPath = "~/" + category + "/" + ImageName; // your code goes here
                var path = Path.Combine(Server.MapPath("~/images/" + category), ImageName);
                string subpath = "~/images/" + category;
   

                bool exists = System.IO.Directory.Exists(Server.MapPath(subpath));

                if (!exists) {
                    System.IO.Directory.CreateDirectory(Server.MapPath(subpath));
                }
                   
                                

                // save image in folder
                file.SaveAs(path);
                

                //save new record in database
               datum newRecord = new datum();
                newRecord.category = Request.Form["category"];
                newRecord.description = Request.Form["description"];
                newRecord.imagePath = ImageName;
                db.data.Add(newRecord);
                db.SaveChanges();
               

            }
            //Display records
            return RedirectToAction("Display");
        }

        public ActionResult Display()
        {
            return View();
        }
	}
}