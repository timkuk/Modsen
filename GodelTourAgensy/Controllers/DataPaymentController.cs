using GodelTourAgensy.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GodelTourAgensy.Web.Controllers
{
    public class DataPaymentController : Controller
    {
        private readonly IPackagesService packagesService;

        public DataPaymentController(IPackagesService packagesService)
        {
            this.packagesService = packagesService;
        }

        [HttpGet]
        public IActionResult PaymentPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BookingPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostPopular()
        {
            return View(packagesService.GetMostPopular());
        }
    }
}

