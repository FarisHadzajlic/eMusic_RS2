using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Database
{
    public class UserLikedTrack
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int TrackID { get; set; }
        public virtual Track Track { get; set; }
    }
}
