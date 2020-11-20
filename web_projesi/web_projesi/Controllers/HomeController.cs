using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_projesi.Models.DataContext;

namespace web_projesi.Controllers
{
    public class HomeController : Controller
    {
        private YazilimDeposuDBContext db = new YazilimDeposuDBContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList();
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);

            return View();
        }

        public ActionResult SliderPartial() //Slider tablosundaki menüleri getir.
        {

            //slider en son eklenen resmi önce göster
            return View(db.Slider.ToList());
        }
        public ActionResult HizmetPartial()//Hizmetler tablosundaki menüleri getir.
        {
            return View(db.Hizmet.ToList());
        }


    }
}