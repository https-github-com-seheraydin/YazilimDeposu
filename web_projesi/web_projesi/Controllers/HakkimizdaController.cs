using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_projesi.Models.DataContext;
using web_projesi.Models.Model;

namespace web_projesi.Controllers
{
    public class HakkimizdaController : Controller
    {
        YazilimDeposuDBContext db = new YazilimDeposuDBContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList();
            return View(h);
        }

        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaId == id).FirstOrDefault();
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda h)
        {
            if (ModelState.IsValid)
            {
                var hakkimida = db.Hakkimizda.Where(x => x.HakkimizdaId == id).SingleOrDefault();

                hakkimida.Aciklama = h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(h);
        }
    }
}