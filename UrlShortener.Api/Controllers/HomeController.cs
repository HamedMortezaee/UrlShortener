using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
