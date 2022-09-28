using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APL_Test.Models;
using System.IO;

namespace APL_Test.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(Image image)
        {
            var filename = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            var extension = Path.GetExtension(image.ImageFile.FileName);
            var allowedExt = new[] { "jpg", "png" };
            
            try
            {
                if (!allowedExt.Contains(extension))
                {
                   image.ErrorMessage = "Invalid File Extension. Please upload only JPG or PNG files";
                }
                else
                {
                    image.ErrorMessage = "Image uploaded successfully";
                }
            }
            catch(Exception e)
            {
                image.ErrorMessage = "Upload container should not be empty.";
                return View(image);
            }
            
            return View();
        }
    }
}