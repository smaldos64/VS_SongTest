using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongTest.Models
{
    public class User
    {
        public int userID { get; set; }

        [Required]
        public string userFirstName { get; set; }

        [Required]
        public string userLastName { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}