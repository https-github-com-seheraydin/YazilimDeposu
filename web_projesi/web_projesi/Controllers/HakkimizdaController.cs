using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_projesi.Models.DataContext;

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
    }
}