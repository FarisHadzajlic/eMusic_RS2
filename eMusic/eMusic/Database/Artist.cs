using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }
        [Key]
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Founded { get; set; }
        public string Origin { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
