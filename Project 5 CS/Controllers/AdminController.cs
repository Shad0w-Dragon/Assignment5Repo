using Microsoft.AspNetCore.Mvc;
using Project_5_CS.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project_5_CS.Controllers
{
    public class AdminController : Controller
    {
        private readonly MusicDbContext _context;

        public AdminController(MusicDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Music> musicList = _context.Music.ToList();
            return View(musicList);
        }

        [HttpPost]
        public IActionResult AddSong(Music newSong)
        {
            if (ModelState.IsValid)
            {
                int nextId = _context.Music.Any() ? _context.Music.Max(m => m.Id) + 1 : 1;
                newSong.Id = nextId;
                _context.Music.Add(newSong);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveSong(int songId)
        {
            var songToRemove = _context.Music.FirstOrDefault(m => m.Id == songId);
            if (songToRemove != null)
            {
                _context.Music.Remove(songToRemove);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
    }
}
