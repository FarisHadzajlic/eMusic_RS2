using System;
using System.Collections.Generic;
using System.Text;

namespace eMusic.Model.ViewModels
{
    public class AlbumListVM
    {
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public int NumberOfTracks { get; set; }
        public float Price { get; set; }
    }
}
