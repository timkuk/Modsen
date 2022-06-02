using GodelTourAgensy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GodelTourAgensy.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Payment()
        {
            return RedirectToAction("Index", "DataPayment");
        }

        public IActionResult ErrorIndex(ErrorViewModel error)
        {
            return View(error);
        }

        public IActionResult Package()
        {
            return RedirectToAction("Index", "DataPackage");
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
