using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using web_projesi.Models;
using web_projesi.Models.DataContext;
using web_projesi.Models.Model;

namespace web_projesi.Controllers
{
    public class AdminController : Controller
    {


        YazilimDeposuDBContext db = new YazilimDeposuDBContext();

        // GET: Admin
        [Route("yonetimpaneli")]
        public ActionResult Index()
        {
            ViewBag.BlogSay = db.Blog.Count();
            ViewBag.KategoriSay = db.Kategori.Count();
            ViewBag.HizmetSay = db.Hizmet.Count();
            ViewBag.SiteAciklamaSay = db.Kimlik.Count();
            var sorgu = db.Admin.ToList();
            return View(sorgu);
        }

        //login action 
        [Route("/yonetimpaneli/giris")]
        public ActionResult Login()
        {
            return View();
        }

        //post metodu
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            //bize gelen e posta modelden gelen e posta eşleşme kontrolü
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            if (login.Eposta == admin.Eposta && login.Sifre == admin.Sifre)
            {
                //oturum değişkeni oluştur-->session
                Session["adminid"] = login.AdminId;
                Session["eposta"] = login.Eposta;
                //Giriş yaptıktan sonra adminin indexine git
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı ya da şifre yanlış!";
            return View(admin);

        }
        public ActionResult Logout()
        {
            //oturum sonlandır
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");

        }

        public ActionResult Adminler()
        {
            return View(db.Admin.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
    

    }
}