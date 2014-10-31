using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace task.Controllers
{
    public class categoriesController : ApiController
    {
        DataEntry db = new DataEntry();

        public List<string> GetCategories()
        {

            var category = db.data.Select(m => m.category).ToList();


            return category;
        }
    }
}
