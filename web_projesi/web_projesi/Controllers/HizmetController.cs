using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_projesi.Models.DataContext;

namespace web_projesi.Controllers
{
    public class HizmetController : Controller
    {
        private YazilimDeposuDBContext db = new YazilimDeposuDBContext();
        // GET: Hizmet
        public ActionResult Index()
        {
            return View();
        }
    }
}