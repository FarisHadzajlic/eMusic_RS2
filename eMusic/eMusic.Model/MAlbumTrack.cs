using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MAlbumTrack
    {
        public int AlbumID { get; set; }
        public int TrackID { get; set; }
        public MTrack Track { get; set; }
    }
}
