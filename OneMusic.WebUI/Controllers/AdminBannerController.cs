using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    public class AdminBannerController : Controller
    {
        private readonly IBannerService _bannerService;

        public AdminBannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IActionResult Index()
        {
            var values = _bannerService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBanner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBanner(Banner banner)
        {
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteBanner(int id)
        {
            _bannerService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateBanner(int id)
        {
            var values = _bannerService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateBanner(Banner banner)
        {
            _bannerService.TUpdate(banner);
            return RedirectToAction("Index");
        }
    }
}
