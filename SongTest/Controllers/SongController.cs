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

        public ActionResult SongDetails(int Id)
        {
            Song Song_Object = db_Object.Songs.Find(Id);

            if (null != Song_Object)
            {
                return (View(Song_Object));
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
            }
        }

        public ActionResult DeleteSong(int Id)
        {
            Song Song_Object = db_Object.Songs.Find(Id);

            if (null != Song_Object)
            {
                db_Object.Songs.Remove(Song_Object);
                db_Object.SaveChanges();
            }
            return (RedirectToAction("Songlist", "Song"));
        }

        public ActionResult EditSong(int Id)
        {
            Song Song_Object = db_Object.Songs.Find(Id);

            if (null != Song_Object)
            {
                ViewBag.GenreList = db_Object.Genres.ToList();

                return (View(Song_Object));
            }
            else
            {
                return (RedirectToAction("Songlist", "Song"));
            }
        }

        [HttpPost]
        public ActionResult EditSong(Song Song_Object)
        {
            int NumberOfRecordsSaved = 0;

            Song Song_ObjectSave = db_Object.Songs.Find(Song_Object.SongID);
            Song_ObjectSave.GenreID = Song_Object.GenreID;
            Song_ObjectSave.SongTitle = Song_Object.SongTitle;

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
    }
}