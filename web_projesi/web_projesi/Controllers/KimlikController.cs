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
    public class KimlikController : Controller
    {
        //data context 
        YazilimDeposuDBContext db = new YazilimDeposuDBContext();

        // GET: Kimlik
        public ActionResult Index()
        {
            //db den kimlik değerlerini listeleyelim
            return View(db.Kimlik.ToList());
        }

       

        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Kimlik kimlik, HttpPostedFileBase LogoURL)
        {
            //model doğrulandıysa işlemlere geç
            if (ModelState.IsValid)
            {
                var k = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
                if (LogoURL !=null)
                {
                    //daha önce kaydetmiş olunan dosya kontrolü
                    if (System.IO.File.Exists(Server.MapPath(k.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.LogoURL));
                    }

                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);

                    String logoname = LogoURL.FileName +imginfo.Extension;
                    img.Resize(150, 150);
                    img.Save("~/Uploads/Kimlik/"+logoname );

                    k.LogoURL = "/Uploads/Kimlik/" + logoname;
                    
                }
                k.Title = kimlik.Title;
                k.Keywords= kimlik.Keywords;
                k.Description = kimlik.Description;
                k.Unvan = kimlik.Unvan;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kimlik);
        }

      

     
    }
}
