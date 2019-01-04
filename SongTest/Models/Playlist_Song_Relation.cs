using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongTest.Models
{
    public class Playlist_Song_Relation
    {
        [Key, Column(Order = 0)]
        public int Playlist_Song_RelationID { get; set; }

        public int PlaylistID { get; set; }
        public virtual Playlist Playlist { get; set; }

        public int SongID { get; set; }
        public virtual Song Song { get; set; }
    }
}