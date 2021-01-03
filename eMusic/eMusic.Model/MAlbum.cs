using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MAlbum
    {
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public byte[] Image { get; set; }
        public int NumberOfTracks { get; set; }
        public string About { get; set; }
        public float Price { get; set; }
        public int ArtistID { get; set; }
        public int GenreID { get; set; }
        public MArtist Artist { get; set; }
        public MGenre Genre { get; set; }
        public ICollection<MAlbumTrack> AlbumTracks { get; set; }
    }
}
