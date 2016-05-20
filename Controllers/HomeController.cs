using Microsoft.AspNetCore.Mvc;

namespace Azured.Web.Api.Controllers
{
    public class HomeController : Controller
    {    
        public IActionResult Index()
        {
            return Content("Azured.io API");
        }
    }
}
