using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class Track
    {
        public Track()
        {
            AlbumTracks = new HashSet<AlbumTrack>();
            PlaylistTracks = new HashSet<PlaylistTrack>();
            UserTrackReviews = new HashSet<UserTrackReview>();
        }
        [Key]
        public int TrackID { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public byte[] Mp3file { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }   
        public virtual Artist Artist { get; set; }
        public virtual Genre Grene { get; set; }
        public virtual ICollection<AlbumTrack> AlbumTracks { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual ICollection<UserTrackReview> UserTrackReviews { get; set; }
    }
}
