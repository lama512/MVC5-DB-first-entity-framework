using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace task.Controllers
{
    public class ImagesController : ApiController
    {
        DataEntry db = new DataEntry();

        public List<string> GetImage()
        {
         
            var imagePath = db.data.Select(m => m.imagePath).ToList();
            
          
            return imagePath;
         }

     
        public IHttpActionResult GetImages(int id)
        {
            var imagePath = db.data.Where(m => m.Id == id).Select(m => m.imagePath).FirstOrDefault();
            if (imagePath == null)
            {
                return NotFound();
            }
            return Ok(imagePath);
        }
    }
}
