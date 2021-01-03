using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class PlaylistTrack
    {
        public int PlaylistID { get; set; }
        public virtual Playlist Playlist { get; set; }
        public int TrackID { get; set; }
        public virtual Track Track { get; set; }
    }
}
