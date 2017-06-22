using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessLogger.obj;
using FitnessLogger.Models;

namespace FitnessLogger.Controllers
{
    public class HomeController : Controller
    {

        private PostGreSQL db = new PostGreSQL();

        public ActionResult Index()
        {

            List<LogRow> LogList = db.Exercises;

            return View(LogList);
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LogRow LogEntry)
        {
            LogEntry.Date = DateTime.Now;

            if(ModelState.IsValid)
            {
                db.AddExercise(LogEntry);

                return RedirectToAction("Index");
            }
            

            return View(LogEntry);
        }
    }
}