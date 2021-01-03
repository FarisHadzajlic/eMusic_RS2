using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model.Request
{
    public class BuyAlbumSearchRequest
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? GenreID { get; set; }
        public int AlbumID { get; set; }
    }
}
