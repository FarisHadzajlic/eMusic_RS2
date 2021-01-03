using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eMusic.Model.Request
{
    public class PlaylistUpsertRequest
    {
        [Required]
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public byte[] Image { get; set; }
        public string Username { get; set; }
        [Required]
        public int UserID { get; set; }
        public List<int> Tracks { get; set; } = new List<int>();
        public List<int> TracksToDelete { get; set; } = new List<int>();
    }
}
