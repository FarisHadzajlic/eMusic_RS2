using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eMusic.Model.Request
{
    public class AlbumUpsertRequest
    {
        [Required]
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public byte[] Image { get; set; }
        public int NumberOfTracks { get; set; }
        public string About { get; set; }
        public float Price { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }
        public List<int> Tracks { get; set; } = new List<int>();
        public List<int> TracksToDelete { get; set; } = new List<int>();
    }
}
