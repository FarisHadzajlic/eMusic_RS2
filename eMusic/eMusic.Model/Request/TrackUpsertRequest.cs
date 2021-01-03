using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eMusic.Model.Request
{
    public class TrackUpsertRequest
    {
        [Required]
        public string Name { get; set; }
        public string Length { get; set; }
        public byte[] MP3File { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }
    }
}
