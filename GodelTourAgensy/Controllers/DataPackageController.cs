using Microsoft.AspNetCore.Mvc;

namespace GodelTourAgensy.Web.Controllers
{
    public class DataPackageController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
