using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Database
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateOfComment { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
    }
}
