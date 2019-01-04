using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongTest.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }

        [Required]
        public string ArtistName { get; set; }

        public string ArtistInfo { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}