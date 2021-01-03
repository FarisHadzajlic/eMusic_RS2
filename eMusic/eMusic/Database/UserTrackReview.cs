using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class UserTrackReview
    {
        [Key]
        public int UserTrackReviewID { get; set; }
        public int UserID { get; set; }
        public int TrackID { get; set; }
        public int Rating { get; set; }
        public virtual Track Track { get; set; }
        public virtual User User { get; set; }
    }
}
