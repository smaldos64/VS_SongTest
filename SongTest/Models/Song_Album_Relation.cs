using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SongTest.Models
{
    public class Song_Album_Relation
    {
        //[Key, Column(Order = 0)]
        //public int Song_Album_RelationID { get; set; }

        [Key, Column(Order = 0)]
        public int SongID { get; set; }
        public virtual Song Song { get; set; }

        [Key, Column(Order = 1)]
        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }
    }
}