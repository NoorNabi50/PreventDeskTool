using Microsoft.AspNetCore.Mvc;

namespace PreventDeskTool.Controllers
{
    public class LandingWebsiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
