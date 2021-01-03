using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model.Request
{
    public class BuyAlbumRequest
    {
        public DateTime DateOfBuying { get; set; }
        public int UserID { get; set; }
        public int AlbumID { get; set; }
        public string Username { get; set; }
        public string AlbumName { get; set; }
        public float Price { get; set; }
    }
}
