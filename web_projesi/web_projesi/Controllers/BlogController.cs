using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using web_projesi.Models.DataContext;
using web_projesi.Models.Model;

namespace web_projesi.Controllers
{
    public class BlogController : Controller
    {
        private YazilimDeposuDBContext db = new YazilimDeposuDBContext();
        // GET: Blog
        
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var b = db.Blog.Include("Kategori").ToList().OrderByDescending(x=>x.BlogId);
            return View(b);
        }
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategori, "KategoriId", "KategoriAd");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog, HttpPostedFileBase ResimURL)
        {
            if (ResimURL != null)
            {
               
                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);

                String blogImgName = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(600, 400);
                img.Save("~/Uploads/Blog/" + blogImgName);

                blog.ResimURL = "/Uploads/Blog/" + blogImgName;

            }
            db.Blog.Add(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}