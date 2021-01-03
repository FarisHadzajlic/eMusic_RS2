using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class Album
    {
        public Album()
        {
            AlbumTracks = new HashSet<AlbumTrack>();
        }
        [Key]
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public byte[] Image { get; set; }
        public int NumberOfTracks { get; set; }
        public string About { get; set; }
        public float Price { get; set; }
        public int ArtistID { get; set; }
        public int GenreID { get; set; }        
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<AlbumTrack> AlbumTracks { get; set; }
    }
}
