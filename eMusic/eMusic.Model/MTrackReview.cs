﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MTrackReview
    {
        public int UserTrackReviewID { get; set; }
        public int UserID { get; set; }
        public int TrackID { get; set; }
        public int Rating { get; set; }
    }
}
