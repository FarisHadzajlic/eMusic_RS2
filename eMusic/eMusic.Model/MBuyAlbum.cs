using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MBuyAlbum
    {
        public int BuyAlbumID { get; set; }
        public int UserID { get; set; }
        public int AlbumID { get; set; }
        public DateTime DateOfBuying { get; set; }
        public string Username { get; set; }
        public string AlbumName { get; set; }
        public float Price { get; set; }
        public MUser User { get; set; }
        public MAlbum Album { get; set; }
    }
}
