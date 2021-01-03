using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model
{
    public class MComment
    {
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateOfComment { get; set; }
        public int UserID { get; set; }
        public MUser User { get; set; }
        public int AlbumID { get; set; }
    }
}
