using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}