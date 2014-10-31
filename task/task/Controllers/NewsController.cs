using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace task.Controllers
{
    public class NewsController : ApiController
    {
        DataEntry db = new DataEntry();

        public List<string> GetNews()
        {

            var news = db.data.Select(m => m.description).ToList();


            return news;
        }


        public IHttpActionResult GetNews(int id)
        {
            var news = db.data.Where(m => m.Id == id).Select(m => m.description).FirstOrDefault();
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }
    }
}
