using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongTest.Models
{
    public class Album
    {
        public int AlbumID { get; set; }

        [Required]
        public string AlbumTitle { get; set; }

        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }

        //public virtual ICollection<Song> Songs { get; set; }

        public virtual ICollection<Song_Album_Relation> Song_Album_Relations { get; set; }
    }
}