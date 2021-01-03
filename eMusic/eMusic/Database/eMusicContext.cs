using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMusic.Database
{
    public partial class eMusicContext : DbContext
    {
        public eMusicContext(DbContextOptions<eMusicContext> options)
            : base(options)
        {
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumTrack> AlbumTracks { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<UserTrackReview> UserTrackReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLikedArtist> UserLikedArtists { get; set; }
        public DbSet<UserLikedTrack> UserLikedTracks { get; set; }
        public DbSet<BuyAlbum> BuyAlbums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumTrack>()
                .HasKey(k => new { k.AlbumID, k.TrackID });
            modelBuilder.Entity<PlaylistTrack>()
                .HasKey(k => new { k.PlaylistID, k.TrackID });
            modelBuilder.Entity<UserLikedArtist>()
                .HasKey(k => new { k.UserID, k.ArtistID });
            modelBuilder.Entity<UserLikedTrack>()
                .HasKey(k => new { k.UserID, k.TrackID });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
