using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongTest.Models
{
    public class Song
    {
        public int SongID { get; set; }

        [Required]
        public string SongTitle { get; set; }

        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}