using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class Playlist
    {
        public Playlist()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }
        [Key]
        public int PlaylistID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] Image { get; set; }
        public string Username { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
