using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model.Request
{
    public class UserSearchRequest
    {
        public string Username { get; set; }
        public int PlaylistID { get; set; }
    }
}
