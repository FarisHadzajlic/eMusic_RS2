using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Mobile.Models
{
    public enum MenuType
    {
        YourLibrary,
        SearchMusic,
        BuyAlbum,
        Settings,
        Logout
    }
    public class MeniItems
    {
        public MenuType ID { get; set; }
        public string Title { get; set; }
    }
}
