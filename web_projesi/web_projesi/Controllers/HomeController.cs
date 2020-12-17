using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
            ViewBag.Kategori = db.Kategori.ToList().OrderByDescending(x => x.KategoriId);
            ViewBag.Kimlik = db.Kimlik.ToList();

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

        public ActionResult Hakkimizda()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList();
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            ViewBag.Kategori = db.Kategori.ToList().OrderByDescending(x => x.KategoriId);
            ViewBag.Kimlik = db.Kimlik.ToList();
            return View(db.Hakkimizda.SingleOrDefault());
        }
        public ActionResult Hizmetlerimiz()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList();
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            ViewBag.Kategori = db.Kategori.ToList().OrderByDescending(x => x.KategoriId);
            ViewBag.Kimlik = db.Kimlik.ToList();
            return View(db.Hizmet.ToList());
        }
        public ActionResult Iletisim()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList();
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            ViewBag.Kategori = db.Kategori.ToList().OrderByDescending(x => x.KategoriId);
            ViewBag.Kimlik = db.Kimlik.ToList();
            return View(db.Iletisim.SingleOrDefault());
        }
        public ActionResult DuyuruBasvuruları()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList();
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            ViewBag.Kategori = db.Kategori.ToList().OrderByDescending(x => x.KategoriId);
            ViewBag.Kimlik = db.Kimlik.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruBasvuruları(string AdSoyad=null,string email=null, string Konu=null,string Mesaj=null,string Number=null)
        {
            if (AdSoyad != null && email != null && Konu !=null && Mesaj != null && Number !=null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "yazilimdeposu09@gmail.com";
                WebMail.Password = "YazilimDeposu0935";
                WebMail.SmtpPort = 587;
                WebMail.Send("yazilimdeposu09@gmail.com", Konu , email + "   " + Mesaj);
           

            }
          
            ViewBag.Hizmetler = db.Hizmet.ToList();
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            ViewBag.Kategori = db.Kategori.ToList().OrderByDescending(x => x.KategoriId);
            ViewBag.Kimlik = db.Kimlik.ToList();
            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Hizmetler = db.Hizmet.ToList();
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogId);
            ViewBag.Kategori = db.Kategori.ToList().OrderByDescending(x => x.KategoriId);
            ViewBag.Kimlik = db.Kimlik.ToList();
            return View(db.Blog.Include("Kategori").ToList().OrderByDescending(x => x.BlogId));

        }
        public ActionResult BlogKategoriPartial()
        {
            return PartialView(db.Kategori.ToList().OrderBy(x=>x.KategoriAd));
        }
    }
}