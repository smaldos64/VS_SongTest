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
    }
}