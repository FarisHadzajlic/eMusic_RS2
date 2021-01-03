using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MArtist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Founded { get; set; }
        public string Origin { get; set; }
        public byte[] Image { get; set; }
    }
}
