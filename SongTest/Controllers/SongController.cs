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
            // Eksempler på at anvende et lamdba expression herunder. 
            //List<Song> SongList = db_Object.Songs.Where(g => g.GenreID== 1).ToList();
            //List<Song> SongList = db_Object.Songs.Where(g => g.GenreID == 1 && g.SongID == 1).ToList();
            List<Song> SongList = db_Object.Songs.ToList();
            return (View(SongList));
        }

        public ActionResult CreateSong()
        {
            List<Genre> GenreList = db_Object.Genres.ToList();
            ViewBag.AlbumList = db_Object.Albums.ToList();
            ViewBag.PlayList = db_Object.Playlists.ToList();

            return (View(GenreList));
        }

        [HttpPost]
        public ActionResult CreateSong(Song Song_Object, int AlbumID, int PlayListID)
        {
            bool SaveErrorFound = false;
            int NumberOfRecordsSaved = 0;

            if (ModelState.IsValid)
            {
                db_Object.Songs.Add(Song_Object);
                NumberOfRecordsSaved = db_Object.SaveChanges();

                if (NumberOfRecordsSaved > 0)
                {
                    if (AlbumID > 0)
                    {
                        Song_Album_Relation Song_Album_Relation_Object = new Song_Album_Relation();
                        Song_Album_Relation_Object.SongID = Song_Object.SongID;
                        Song_Album_Relation_Object.AlbumID = AlbumID;
                        db_Object.Song_Album_Relations.Add(Song_Album_Relation_Object);
                        NumberOfRecordsSaved = db_Object.SaveChanges();

                        if (0 == NumberOfRecordsSaved)
                        {
                            SaveErrorFound = true;
                        }
                    }

                    if ( (!SaveErrorFound) && (0 != PlayListID) )
                    {
                        Playlist_Song_Relation Playlist_Song_Relation_Object = new Playlist_Song_Relation();
                        Playlist_Song_Relation_Object.SongID = Song_Object.SongID;
                        Playlist_Song_Relation_Object.PlaylistID = PlayListID;
                        db_Object.Playlist_Song_Relations.Add(Playlist_Song_Relation_Object);
                        NumberOfRecordsSaved = db_Object.SaveChanges();

                        if (0 == NumberOfRecordsSaved)
                        {
                            SaveErrorFound = true;
                        }
                    }
                }
                else
                {
                    SaveErrorFound = true;
                }
            }
            else
            {
                SaveErrorFound = true;
                return (View());
            }

            if (!SaveErrorFound)
            {
                return (RedirectToAction("Songlist", "Song"));
            }
            else
            {
                return (RedirectToAction("Index", "Home"));
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