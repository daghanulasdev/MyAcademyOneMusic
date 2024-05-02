using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    public class AdminSingerController : Controller
    {
        private readonly ISingerService _singerService;

        public AdminSingerController(ISingerService singerService)
        {
            _singerService = singerService;
        }

        public IActionResult Index()
        {
            var values = _singerService.TGetList();
            return View(values);
        }
        public IActionResult DeleteSinger(int id)
        {
            _singerService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddSinger()
            { return View(); }

        [HttpPost]
        public IActionResult AddSinger(Singer singer)
        {
            _singerService.TCreate(singer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSinger(int id)
        {
            var values = _singerService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSinger(Singer singer)
        {
            _singerService.TUpdate(singer);
            return RedirectToAction("Index");
        }
    }
}
