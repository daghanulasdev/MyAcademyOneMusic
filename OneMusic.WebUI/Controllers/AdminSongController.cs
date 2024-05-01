using Microsoft.AspNetCore.Mvc;

namespace OneMusic.WebUI.Controllers
{
    public class AdminSongController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
