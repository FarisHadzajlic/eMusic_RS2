using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MPlaylist
    {
        public int PlaylistID { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public byte[] Image { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public MUser User { get; set; }
        public List<MPlaylistTrack> PlaylistTracks { get; set; }
    }
}
