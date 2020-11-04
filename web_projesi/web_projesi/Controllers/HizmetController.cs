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
    public class HizmetController : Controller
    {
        private YazilimDeposuDBContext db = new YazilimDeposuDBContext();
        // GET: Hizmet
        public ActionResult Index()
        {
            return View(db.Hizmet.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Hizmet hizmet,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                 
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    String logoname = ResimURL.FileName + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hizmet/" + logoname);

                    hizmet.ResimURL = "/Uploads/Hizmet/" + logoname;

                }
                db.Hizmet.Add(hizmet);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(hizmet);
        }
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                ViewBag.Uyari = "Güncellenecek hizmet bullunamadı";
            }
            var hizmet = db.Hizmet.Find(id);
            if (hizmet==null)
            {
                return HttpNotFound();
            }

            return View(hizmet);
        }
    }
}