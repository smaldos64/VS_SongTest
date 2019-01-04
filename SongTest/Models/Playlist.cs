using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongTest.Models
{
    public class Playlist
    {
        public int PlayListID { get; set; }

        [Required]
        public string PlayListName { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Playlist_Song_Relation> Playlist_Song_Relations { get; set; }
    }
}