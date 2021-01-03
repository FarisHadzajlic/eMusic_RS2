using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMusic.Database
{
    public class User
    {
        public User()
        {
            Playlists = new HashSet<Playlist>();
            UserRoles = new HashSet<UserRole>();
            UserTrackReviews = new HashSet<UserTrackReview>();
        }
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserTrackReview> UserTrackReviews { get; set; }
    }
}
