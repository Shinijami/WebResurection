using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebResurection.Repositories.EF;
using WebResurection.ViewModels;

namespace WebResurection.Controllers
{
    public class HomeController : Controller
    {
        private WebResurection_Context db = new WebResurection_Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from player in db.Players
                                                   group player by player.CreateDate into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       JoinDate = dateGroup.Key,
                                                       PlayerCount = dateGroup.Count()
                                                   };
            //ViewBag.Message = "Your application description page.";

            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}