using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_projesi.Models;

namespace web_projesi.Controllers
{
    public class AdminController : Controller
    {
        //veri tabanındaki tablolara erişmek için
        YazilimDeposuDBEntities db = new YazilimDeposuDBEntities();


        // GET: Admin
        public ActionResult Index()
        {
            //kategorileri liste şeklinde gösteren bir sorgu oluşturalım
            var sorgu = db.Kategoris.ToList();
            return View(sorgu);
        }
    }
}