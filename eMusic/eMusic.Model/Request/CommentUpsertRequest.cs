using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model.Request
{
    public class CommentUpsertRequest
    {
        public string CommentContent { get; set; }
        public DateTime DateOfComment { get; set; }
        public int UserID { get; set; }
        public MUser User { get; set; }
        public int AlbumID { get; set; }
    }
}
