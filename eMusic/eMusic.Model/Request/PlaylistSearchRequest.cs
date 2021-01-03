using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model.Request
{
    public class PlaylistSearchRequest
    {
        public int UserID { get; set; }
        public string Name { get; set; }
    }
}
