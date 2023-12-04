using Microsoft.AspNetCore.Mvc;
using Project_5_CS.Models;
using System.Linq;

namespace Project_5_CS.Controllers
{
    public class MusicStoreController : Controller
    {
        private readonly MusicDbContext _context;

        public MusicStoreController(MusicDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var musicList = _context.Music.ToList();
            return View("Index", musicList);
        }

        [HttpGet]
        public IActionResult GetArtistsByGenre(string genre)
        {
            var artists = _context.Music.Where(m => m.Genre == genre).Select(m => m.Creator).Distinct().ToList();
            return Json(artists);
        }

        [HttpGet]
        public IActionResult GetSongsByArtistAndGenre(string genre, string artist)
        {
            var songs = _context.Music.Where(m => m.Genre == genre && m.Creator == artist).ToList();
            return Json(songs);
        }
    }
}
