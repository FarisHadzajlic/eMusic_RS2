using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Database
{
    public class BuyAlbum
    {
        [Key]
        public int BuyAlbumID { get; set; }
        public int UserID { get; set; }
        public int AlbumID { get; set; }
        public DateTime DateOfBuying { get; set; }
        public float Price { get; set; }
        public string Username { get; set; }
        public string AlbumName { get; set; }
        public virtual User User { get; set; }
        public virtual Album Album { get; set; }
    }
}
