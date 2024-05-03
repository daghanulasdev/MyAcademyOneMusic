using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneMusic.BusinessLayer.Abstract;
using OneMusic.EntityLayer.Entities;

namespace OneMusic.WebUI.Controllers
{
    public class AdminAlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly ISingerService _singerService;

        public AdminAlbumController(IAlbumService albumService, ISingerService singerService)
        {
            _albumService = albumService;
            _singerService = singerService;
        }

        public IActionResult Index()
        {
            var values = _albumService.TGetAlbumWithSingers();
            return View(values);
        }
        public IActionResult DeleteAlbum(int id)
        {
            _albumService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAlbum()
        {
            List<SelectListItem> singer = (from x in _singerService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text=x.SingerName,
                                               Value=x.SingerId.ToString(),
                                           }).ToList();
            ViewBag.singerList = singer;
            return View();
        }

        [HttpPost]
        public IActionResult AddAlbum(Album album)
        {
            _albumService.TCreate(album);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAlbum(int id)
        {
            List<SelectListItem> singer = (from x in _singerService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.SingerName,
                                               Value = x.SingerId.ToString(),
                                           }).ToList();
            ViewBag.singerList = singer;
            var values = _albumService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAlbum(Album album)
        {
            _albumService.TUpdate(album);
            return RedirectToAction("Index");
        }
    }
}
