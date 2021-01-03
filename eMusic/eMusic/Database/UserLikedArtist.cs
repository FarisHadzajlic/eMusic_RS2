using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Database
{
    public class UserLikedArtist
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int ArtistID { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
