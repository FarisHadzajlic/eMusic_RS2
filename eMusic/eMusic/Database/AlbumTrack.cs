using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class AlbumTrack
    {
        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }
        public int TrackID { get; set; } 
        public virtual Track Track { get; set; }
    }
}
