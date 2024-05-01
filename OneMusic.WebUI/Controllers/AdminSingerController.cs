using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.Controllers
{
    public class AdminSingerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
