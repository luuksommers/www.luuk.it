using LuukitWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LuukitWebsite.Controllers
{
    public class HomeController : Controller
    {
        ProjectsContext _context;
        public HomeController(ProjectsContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Projects()
        {
            var projects = _context.Projects.OrderByDescending(a=>a.SortingOrder);
            return View(projects);
        }

        public ActionResult Project(int id)
        {
            var project = _context.Projects.SingleOrDefault(a => a.Id == id);

            if (project == null)
            {
                return new HttpNotFoundResult(string.Format("Project with Id {0} does not exist", id));
            }
                
            return View(project);
        }

        public ActionResult Connect()
        {
            return View();
        }
    }
}
