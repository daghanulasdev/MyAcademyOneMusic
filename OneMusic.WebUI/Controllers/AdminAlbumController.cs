using Microsoft.AspNetCore.Mvc;
using OneMusic.BusinessLayer.Abstract;

namespace OneMusic.WebUI.Controllers
{
    public class AdminAlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AdminAlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IActionResult Index()
        {
            var values = _albumService.TGetAllWithSingers();
            return View(values);
        }
    }
}
