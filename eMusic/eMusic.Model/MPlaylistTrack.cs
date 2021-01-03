using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MPlaylistTrack
    {
        public int PlaylistID { get; set; }
        public int TrackID { get; set; }
        public MTrack Track { get; set; }
    }
}
