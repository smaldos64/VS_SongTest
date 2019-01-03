using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongTest.Models
{
    public class Genre
    {
        public int GenreID { get; set; }

        [Required]
        public string GenreTitle { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}