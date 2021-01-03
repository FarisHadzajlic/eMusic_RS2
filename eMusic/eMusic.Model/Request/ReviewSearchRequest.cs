using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model.Request
{
    public class ReviewSearchRequest
    {
        public int UserID { get; set; }
        public int TrackID { get; set; }
        public int Rating { get; set; }
    }
}
