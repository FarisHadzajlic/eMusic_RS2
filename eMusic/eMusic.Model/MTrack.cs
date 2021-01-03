using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MTrack
    {
        public int TrackID { get; set; }
        public string Name { get; set; }
        public string Length { get; set; }
        public byte[] MP3File { get; set; }
        public int ArtistID { get; set; }
        public MArtist Artist { get; set; }
    }
}
