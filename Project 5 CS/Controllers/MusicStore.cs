namespace Project_5_CS.Models
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MusicStoreController : Controller
    {
        private readonly MusicDbContext _context;

        public MusicStoreController(MusicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _context.Music
                .Select(m => m.Genre)
                .Distinct()
                .ToListAsync();

            return Json(genres);
        }
        [HttpGet]
        public async Task<IActionResult> GetPerformersByGenre(string genre)
        {
            var performers = await _context.Music
                .Where(m => m.Genre == genre)
                .Select(m => m.Creator)
                .Distinct()
                .ToListAsync();

            return Json(performers);
        }

      
        [HttpGet]
        public IActionResult GetSongsByPerformerAndGenre(string performer, string genre)
        {
            var songs = _context.Music
                .Where(m => m.Creator == performer && m.Genre == genre)
                .ToList();

            return Json(songs);
        }
        public async Task<IActionResult> ListAll()
        {
            var allSongs = await _context.Music.ToListAsync();
            return View(allSongs);
        }
    }
}