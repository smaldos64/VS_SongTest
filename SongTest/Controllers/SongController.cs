using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SongTest.Models;

namespace SongTest.Controllers
{
    public class SongController : Controller
    {
        private DatabaseContext db_Object = new DatabaseContext();

        // GET: Song
        public ActionResult SongList()
        {
            List<Song> SongList = db_Object.Songs.ToList();
            return (View(SongList));
        }

        public ActionResult CreateSong()
        {
            List<Genre> GenreList = db_Object.Genres.ToList();
            return (View(GenreList));
        }

        [HttpPost]
        public ActionResult CreateSong(Song Song_Object)
        {
            int NumberOfRecordsSaved = 0;

            if (ModelState.IsValid)
            {
                db_Object.Songs.Add(Song_Object);
                NumberOfRecordsSaved = db_Object.SaveChanges();

                if (NumberOfRecordsSaved > 0)
                {
                    return (RedirectToAction("SongList", "Song"));
                }
                else
                {
                    return (RedirectToAction("Index", "Home"));
                }
            }
            else
            {
                return (View());
            }
        }
    }
}