using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Database
{
    public partial class eMusicContext
    {
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            List<string> Salt = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                Salt.Add(GenerateSalt());
            }
            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    UserID = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Username = "Admin",
                    Email = "admin@emusic.com",
                    PhoneNumber = "061435234",
                    Image = File.ReadAllBytes("Files/Images/user.png"),
                    PasswordSalt = Salt[0],
                    PasswordHash = GenerateHash(Salt[0], "Admin123.")
                },
                new User
                {
                    UserID = 2,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Username = "Desktop",
                    Email = "adminDeskop@emusic.com",
                    PhoneNumber = "061525234",
                    Image = File.ReadAllBytes("Files/Images/user.png"),
                    PasswordSalt = Salt[1],
                    PasswordHash = GenerateHash(Salt[1], "Admin123.")
                },
                new User
                {
                    UserID = 3,
                    FirstName = "Mobile",
                    LastName = "Mobile",
                    Username = "Mobile",
                    Email = "mobile@emusic.com",
                    PhoneNumber = "061121237",
                    Image = File.ReadAllBytes("Files/Images/user.png"),
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Mobile123.")
                }
            );
            modelBuilder.Entity<Role>().HasData
            (
                new Role { RoleID = 1, Name = "Admin" },
                new Role { RoleID = 2, Name = "User" }
            );
            modelBuilder.Entity<UserRole>().HasData
            (
                new UserRole { UserRoleID = 1, UserID = 1, RoleID = 1 },
                new UserRole { UserRoleID = 2, UserID = 2, RoleID = 1 },
                new UserRole { UserRoleID = 3, UserID = 3, RoleID = 2 }
            );
            modelBuilder.Entity<Genre>().HasData
            (
                new Genre { GenreID = 1, Name = "Psychedelic Rock" },
                new Genre { GenreID = 2, Name = "Rock" },
                new Genre { GenreID = 3, Name = "Blues Rock" },
                new Genre { GenreID = 4, Name = "Country Rock" }
            );
            modelBuilder.Entity<Artist>().HasData
            (
                new Artist
                {
                    ArtistID = 1,
                    Name = "Pink Floyd",
                    Founded = "1965",
                    Origin = "London, England",
                    Image = File.ReadAllBytes("Files/Images/Artists/pinkfloyd.jpg")
                },
                new Artist
                {
                    ArtistID = 2,
                    Name = "Creedence Clearwater Revival",
                    Founded = "1976",
                    Origin = "El Cerrito, California, U.S.",
                    Image = File.ReadAllBytes("Files/Images/Artists/ccr.jpg")
                },
                new Artist
                {
                    ArtistID = 3,
                    Name = "Allman Brothers",
                    Founded = "1969",
                    Origin = "Jacksonville, Florida, U.S.",
                    Image = File.ReadAllBytes("Files/Images/Artists/allmanbrothers.jpg")
                },
                new Artist
                {
                    ArtistID = 4,
                    Name = "Grateful Dead",
                    Founded = "1965",
                    Origin = "San Francisco, California, U.S.",
                    Image = File.ReadAllBytes("Files/Images/Artists/gratefuldead.jpg")
                }
            );
            modelBuilder.Entity<Album>().HasData
            (
                new Album
                {
                    AlbumID = 1,
                    ArtistID = 1,
                    GenreID = 1,
                    Name = "The Wall",
                    YearOfRelease = 1979,
                    About = "The Wall is the eleventh studio album by the English rock band Pink Floyd, released on 30th November 1979 by Harvest and Columbia Records. It is a rock opera that explores Pink, a jaded Rockstar whose eventual self-imposed isolation from society forms a figurative wall. The album was a commercial success, topping the US charts for 15 weeks, and reaching number three in the UK. It initially received mixed reviews from critics, many of whom found it overblown and pretentious, but later received accolades as one of the finest albums of all time.",
                    Image = File.ReadAllBytes("Files/Images/Albums/thewall.jpg"),
                    Price = 15,
                    NumberOfTracks = 13
                },
                new Album
                {
                    AlbumID = 2,
                    ArtistID = 1,
                    GenreID = 1,
                    Name = "Animals",
                    YearOfRelease = 1977,
                    About = "Animals is the tenth studio album by the English rock band Pink Floyd, released on 21 January 1977 through Harvest and Columbia Records. It was recorded at the band's Britannia Row Studios in London throughout 1976, and was produced by the band. The album continues the longform compositions that made up their previous works, including Wish You Were Here (1975). The album received positive reviews from critics and was commercially successful, reaching number 2 in the UK and number 3 in the USA.",
                    Image = File.ReadAllBytes("Files/Images/Albums/animals.jpg"),
                    Price = 0,
                    NumberOfTracks = 5
                },
                new Album
                {
                    AlbumID = 3,
                    ArtistID = 2,
                    GenreID = 4,
                    Name = "Green River",
                    YearOfRelease = 1969,
                    About = "Green River is the third studio album by American rock and roll band Creedence Clearwater Revival, released in August 1969. It was the second of three albums they released in that year, preceded by Bayou Country in January and followed by Willy and the Poor Boys in November.",
                    Image = File.ReadAllBytes("Files/Images/Albums/greenriver.jpg"),
                    Price = 10, 
                    NumberOfTracks = 8
                },
                new Album
                {
                    AlbumID = 4,
                    ArtistID = 2,
                    GenreID = 4,
                    Name = "Pendulum",
                    YearOfRelease = 1970,
                    About = "Pendulum is the sixth studio album by American rock band Creedence Clearwater Revival, released by Fantasy Records on December 9, 1970 their second album release of that year. A single from the album, 'Have You Ever Seen the Rain'/'Hey Tonight', was released in January 1971.",
                    Image = File.ReadAllBytes("Files/Images/Albums/pendulum.jpg"),
                    Price = 0,
                    NumberOfTracks = 10
                },
                new Album
                {
                    AlbumID = 5,
                    ArtistID = 3,
                    GenreID = 3,
                    Name = "At Fillmore East",
                    YearOfRelease = 1971,
                    About = "At Fillmore East is the first live album by American rock band the Allman Brothers Band, and their third release overall. Produced by Tom Dowd, the album was released in July 1971 in the United States by Capricorn Records. As the title indicates, the recording took place at the New York City music venue Fillmore East, which was run by concert promoter Bill Graham. It was recorded over the course of three nights in March 1971 and features the band performing extended jam versions of songs such as 'Whipping Post', 'You Don't Love Me' and 'In Memory of Elizabeth Reed.' When first commercially released, it was issued as a double LP with just seven songs across four vinyl sides.",
                    Image = File.ReadAllBytes("Files/Images/Albums/atfillmoreeast.jpg"),
                    Price = 20,
                    NumberOfTracks = 7
                },
                new Album
                {
                    AlbumID = 6,
                    ArtistID = 3,
                    GenreID = 3,
                    Name = "Brothers and Sisters",
                    YearOfRelease = 1973,
                    About = "Brothers and Sisters is the fourth studio album by American rock band The Allman Brothers Band. Co-produced by Johnny Sandlin and the band, the album was released in August 1973 in the United States by Capricorn Records. Following the death of group leader Duane Allman in 1971, the Allman Brothers Band released Eat a Peach (1972), a hybrid studio/live album that became their biggest yet. Afterwards, the group purchased a farm in Juliette, Georgia, to become a 'group hangout'. However, bassist Berry Oakley was visibly suffering from the death of Duane: he excessively drank and consumed drugs. After nearly a year of severe depression, Oakley was killed in a motorcycle accident not dissimilar from his friend's in November 1972 making it the last album to feature Oakley.",
                    Image = File.ReadAllBytes("Files/Images/Albums/brothersandsisters.jpg"),
                    Price = 0,
                    NumberOfTracks = 7
                },
                new Album
                {
                    AlbumID = 7,
                    ArtistID = 4,
                    GenreID = 2,
                    Name = "American Beauty",
                    YearOfRelease = 1970,
                    About = "American Beauty is the fifth studio album by rock band the Grateful Dead. Released November 1, 1970, by Warner Bros. Records, the album continued the folk rock and country music style of their previous album Workingman's Dead, issued earlier in the year. Though the Americana approach is still evident in the songwriting, comparatively the sound focused more on folk harmonies and major-key melodies, showing influence from Bob Dylan and Crosby, Stills, Nash, & Young.",
                    Image = File.ReadAllBytes("Files/Images/Albums/americanbeauty.jpg"),
                    Price = 30,
                    NumberOfTracks = 7
                },
                new Album
                {
                    AlbumID = 8,
                    ArtistID = 4,
                    GenreID = 2,
                    Name = "Wake of the Flood",
                    YearOfRelease = 1973,
                    About = "Wake of the Flood is the sixth studio album by rock band the Grateful Dead. Released October 15, 1973, it was the first album on the band's own Grateful Dead Records label. Their first studio album in nearly three years, it was also the first without founding member Ron 'Pigpen' McKernan, who had recently died. His absence and keyboardist Keith Godchaux's penchants for bebop and modal jazz (rather than McKernan's tendencies toward the blues and soul music) contributed to the band's musical evolution. Godchaux's wife, backing vocalist Donna Jean Godchaux, also joined the group and appears on the album.",
                    Image = File.ReadAllBytes("Files/Images/Albums/wakeoftheflood.jpg"),
                    Price = 0,
                    NumberOfTracks = 7
                }
            );
            modelBuilder.Entity<Track>().HasData
            (
                 new Track { TrackID = 1, Length = new TimeSpan(0, 55, 00), Name = "In The Flesh?", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 2, Length = new TimeSpan(2, 27, 00), Name = "The Thin Ice", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 3, Length = new TimeSpan(3, 16, 00), Name = "Another Brick in the Wall", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 4, Length = new TimeSpan(4, 33, 00), Name = "The Happiest Days of Our Lives", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 5, Length = new TimeSpan(2, 22, 00), Name = "Hey You", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 6, Length = new TimeSpan(3, 44, 00), Name = "Mother", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 7, Length = new TimeSpan(3, 13, 00), Name = "GoodBye Blue Sky", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 8, Length = new TimeSpan(4, 23, 00), Name = "Empty Spaces", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 9, Length = new TimeSpan(5, 02, 00), Name = "Young Lust", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 10, Length = new TimeSpan(6, 45, 00), Name = "One of My Turns", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 11, Length = new TimeSpan(6, 11, 00), Name = "Don't Leave Me Now", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 12, Length = new TimeSpan(5, 52, 00), Name = "Nobody Home", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 13, Length = new TimeSpan(5, 23, 00), Name = "Comfortably Numb", ArtistID = 1, GenreID = 1 },

                 new Track { TrackID = 14, Length = new TimeSpan(1, 24, 00), Name = "Pigs on the Wing (Part 1)", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 15, Length = new TimeSpan(17, 04, 00), Name = "Dogs", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 16, Length = new TimeSpan(11, 28, 00), Name = "Pigs (Three Different Ones)", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 17, Length = new TimeSpan(10, 20, 00), Name = "Sheep", ArtistID = 1, GenreID = 1 },
                 new Track { TrackID = 18, Length = new TimeSpan(1, 24, 00), Name = "Pigs on the Wing (Part 2)", ArtistID = 1, GenreID = 1 },

                 new Track { TrackID = 19, Length = new TimeSpan(3, 22, 00), Name = "Green River", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 20, Length = new TimeSpan(4, 31, 00), Name = "Commotion", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 21, Length = new TimeSpan(6, 25, 00), Name = "Tombstone Shadow", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 22, Length = new TimeSpan(4, 38, 00), Name = "Wrote a Song For Everyone", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 23, Length = new TimeSpan(5, 24, 00), Name = "Bad Moon Rising", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 24, Length = new TimeSpan(3, 23, 00), Name = "Lodi", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 25, Length = new TimeSpan(4, 41, 00), Name = "Cross-Tie Walker", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 26, Length = new TimeSpan(3, 53, 00), Name = "Sinister Purpose", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 27, Length = new TimeSpan(2, 52, 00), Name = "Night Time in the Right Time", ArtistID = 2, GenreID = 4 },

                 new Track { TrackID = 28, Length = new TimeSpan(3, 13, 00), Name = "Pagan Baby", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 29, Length = new TimeSpan(4, 22, 00), Name = "Sailor's Lamet", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 30, Length = new TimeSpan(3, 41, 00), Name = "Chameleon", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 31, Length = new TimeSpan(5, 24, 00), Name = "Have You Ever Seen the Rain", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 32, Length = new TimeSpan(4, 35, 00), Name = "Wish I Could (Hideway)", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 33, Length = new TimeSpan(3, 22, 00), Name = "Born To Move", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 34, Length = new TimeSpan(4, 01, 00), Name = "Hey Tonight", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 35, Length = new TimeSpan(4, 24, 00), Name = "Molina", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 36, Length = new TimeSpan(3, 33, 00), Name = "It's Just a Thought", ArtistID = 2, GenreID = 4 },
                 new Track { TrackID = 37, Length = new TimeSpan(2, 42, 00), Name = "Rude Awakening #2", ArtistID = 2, GenreID = 4 },

                 new Track { TrackID = 38, Length = new TimeSpan(3, 32, 00), Name = "Statesboro Blues", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 39, Length = new TimeSpan(4, 13, 00), Name = "Done Somebody Wrong", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 40, Length = new TimeSpan(4, 45, 00), Name = "Stormy Monday", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 41, Length = new TimeSpan(5, 32, 00), Name = "You Don't Love Me", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 42, Length = new TimeSpan(4, 53, 00), Name = "Hot 'Latina", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 43, Length = new TimeSpan(5, 33, 00), Name = "In Memory of Elizabeth Reed", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 44, Length = new TimeSpan(2, 31, 00), Name = "Whipping Post", ArtistID = 3, GenreID = 3 },

                 new Track { TrackID = 45, Length = new TimeSpan(2, 15, 00), Name = "Wasted Words", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 46, Length = new TimeSpan(3, 42, 00), Name = "Ramblin' Man", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 47, Length = new TimeSpan(4, 23, 00), Name = "Come And Go Blues", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 48, Length = new TimeSpan(5, 43, 00), Name = "Jelly Jelly", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 49, Length = new TimeSpan(5, 56, 00), Name = "Southbound", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 50, Length = new TimeSpan(4, 44, 00), Name = "Jessica", ArtistID = 3, GenreID = 3 },
                 new Track { TrackID = 51, Length = new TimeSpan(6, 33, 00), Name = "Pony Boy", ArtistID = 3, GenreID = 3 },

                 new Track { TrackID = 52, Length = new TimeSpan(1, 42, 00), Name = "Box of Rain", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 53, Length = new TimeSpan(4, 22, 00), Name = "Friend of the Devil", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 54, Length = new TimeSpan(3, 33, 00), Name = "Sugar Magnolia", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 55, Length = new TimeSpan(4, 43, 00), Name = "Operator", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 56, Length = new TimeSpan(5, 25, 00), Name = "Candyman", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 57, Length = new TimeSpan(4, 35, 00), Name = "Ripple", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 58, Length = new TimeSpan(3, 32, 00), Name = "Brokedown Palace", ArtistID = 4, GenreID = 2 },

                 new Track { TrackID = 59, Length = new TimeSpan(1, 24, 00), Name = "Mississippi Half-Step Uptown Toodeloo", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 60, Length = new TimeSpan(2, 33, 00), Name = "Let Me Sing Your Blues Away", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 61, Length = new TimeSpan(4, 32, 00), Name = "Row Jimmy", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 62, Length = new TimeSpan(5, 52, 00), Name = "Stella Blue", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 63, Length = new TimeSpan(5, 44, 00), Name = "Here Comes The Sunshine", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 64, Length = new TimeSpan(6, 45, 00), Name = "Eyes of the World", ArtistID = 4, GenreID = 2 },
                 new Track { TrackID = 65, Length = new TimeSpan(5, 33, 00), Name = "Weather Report Suite", ArtistID = 4, GenreID = 2 }


            );
            modelBuilder.Entity<AlbumTrack>().HasData
            (
                new AlbumTrack { AlbumID = 1, TrackID = 1 },
                new AlbumTrack { AlbumID = 1, TrackID = 2 },
                new AlbumTrack { AlbumID = 1, TrackID = 3 },
                new AlbumTrack { AlbumID = 1, TrackID = 4 },
                new AlbumTrack { AlbumID = 1, TrackID = 5 },
                new AlbumTrack { AlbumID = 1, TrackID = 6 },
                new AlbumTrack { AlbumID = 1, TrackID = 7 },
                new AlbumTrack { AlbumID = 1, TrackID = 8 },
                new AlbumTrack { AlbumID = 1, TrackID = 9 },
                new AlbumTrack { AlbumID = 1, TrackID = 10 },
                new AlbumTrack { AlbumID = 1, TrackID = 11 },
                new AlbumTrack { AlbumID = 1, TrackID = 12 },
                new AlbumTrack { AlbumID = 1, TrackID = 13 },

                new AlbumTrack { AlbumID = 2, TrackID = 14 },
                new AlbumTrack { AlbumID = 2, TrackID = 15 },
                new AlbumTrack { AlbumID = 2, TrackID = 16 },
                new AlbumTrack { AlbumID = 2, TrackID = 17 },
                new AlbumTrack { AlbumID = 2, TrackID = 18 },

                new AlbumTrack { AlbumID = 3, TrackID = 19 },
                new AlbumTrack { AlbumID = 3, TrackID = 20 },
                new AlbumTrack { AlbumID = 3, TrackID = 21 },
                new AlbumTrack { AlbumID = 3, TrackID = 22 },
                new AlbumTrack { AlbumID = 3, TrackID = 23 },
                new AlbumTrack { AlbumID = 3, TrackID = 24 },
                new AlbumTrack { AlbumID = 3, TrackID = 25 },
                new AlbumTrack { AlbumID = 3, TrackID = 26 },
                new AlbumTrack { AlbumID = 3, TrackID = 27 },

                new AlbumTrack { AlbumID = 4, TrackID = 28 },
                new AlbumTrack { AlbumID = 4, TrackID = 29 },
                new AlbumTrack { AlbumID = 4, TrackID = 30 },
                new AlbumTrack { AlbumID = 4, TrackID = 31 },
                new AlbumTrack { AlbumID = 4, TrackID = 32 },
                new AlbumTrack { AlbumID = 4, TrackID = 33 },
                new AlbumTrack { AlbumID = 4, TrackID = 34 },
                new AlbumTrack { AlbumID = 4, TrackID = 35 },
                new AlbumTrack { AlbumID = 4, TrackID = 36 },
                new AlbumTrack { AlbumID = 4, TrackID = 37 },

                new AlbumTrack { AlbumID = 5, TrackID = 38 },
                new AlbumTrack { AlbumID = 5, TrackID = 39 },
                new AlbumTrack { AlbumID = 5, TrackID = 40 },
                new AlbumTrack { AlbumID = 5, TrackID = 41 },
                new AlbumTrack { AlbumID = 5, TrackID = 42 },
                new AlbumTrack { AlbumID = 5, TrackID = 43 },
                new AlbumTrack { AlbumID = 5, TrackID = 44 },

                new AlbumTrack { AlbumID = 6, TrackID = 45 },
                new AlbumTrack { AlbumID = 6, TrackID = 46 },
                new AlbumTrack { AlbumID = 6, TrackID = 47 },
                new AlbumTrack { AlbumID = 6, TrackID = 48 },
                new AlbumTrack { AlbumID = 6, TrackID = 49 },
                new AlbumTrack { AlbumID = 6, TrackID = 50 },
                new AlbumTrack { AlbumID = 6, TrackID = 51 },

                new AlbumTrack { AlbumID = 7, TrackID = 52 },
                new AlbumTrack { AlbumID = 7, TrackID = 53 },
                new AlbumTrack { AlbumID = 7, TrackID = 54 },
                new AlbumTrack { AlbumID = 7, TrackID = 55 },
                new AlbumTrack { AlbumID = 7, TrackID = 56 },
                new AlbumTrack { AlbumID = 7, TrackID = 57 },
                new AlbumTrack { AlbumID = 7, TrackID = 58 },

                new AlbumTrack { AlbumID = 8, TrackID = 59 },
                new AlbumTrack { AlbumID = 8, TrackID = 60 },
                new AlbumTrack { AlbumID = 8, TrackID = 61 },
                new AlbumTrack { AlbumID = 8, TrackID = 62 },
                new AlbumTrack { AlbumID = 8, TrackID = 63 },
                new AlbumTrack { AlbumID = 8, TrackID = 64 },
                new AlbumTrack { AlbumID = 8, TrackID = 65 }
            );
            modelBuilder.Entity<Playlist>().HasData
            (
                new Playlist
                {
                    PlaylistID = 1,
                    UserID = 3,
                    Name = "Workout",
                    Image = File.ReadAllBytes("Files/Images/training.jpg"),
                    CreatedAt = DateTime.Now
                },
                new Playlist
                {
                    PlaylistID = 2,
                    UserID = 3,
                    Name = "Goodnight Collection",
                    Image = File.ReadAllBytes("Files/Images/playlist.jpg"),
                    CreatedAt = DateTime.Now
                },
                new Playlist
                {
                    PlaylistID = 3,
                    UserID = 1,
                    Name = "Test Playlist",
                    Image = File.ReadAllBytes("Files/Images/playlist.jpg"),
                    CreatedAt = DateTime.Now
                }
            );
            modelBuilder.Entity<PlaylistTrack>().HasData
            (
                new PlaylistTrack { PlaylistID = 1, TrackID = 28 },
                new PlaylistTrack { PlaylistID = 1, TrackID = 31 },
                new PlaylistTrack { PlaylistID = 1, TrackID = 33 },
                new PlaylistTrack { PlaylistID = 1, TrackID = 45 },
                new PlaylistTrack { PlaylistID = 1, TrackID = 47 },
                new PlaylistTrack { PlaylistID = 1, TrackID = 50 },
                new PlaylistTrack { PlaylistID = 1, TrackID = 61 },
                new PlaylistTrack { PlaylistID = 1, TrackID = 63 },

                new PlaylistTrack { PlaylistID = 2, TrackID = 29 },
                new PlaylistTrack { PlaylistID = 2, TrackID = 32 },
                new PlaylistTrack { PlaylistID = 2, TrackID = 46 },
                new PlaylistTrack { PlaylistID = 2, TrackID = 45 },
                new PlaylistTrack { PlaylistID = 2, TrackID = 51 },
                new PlaylistTrack { PlaylistID = 2, TrackID = 62 },

                new PlaylistTrack { PlaylistID = 3, TrackID = 15 },
                new PlaylistTrack { PlaylistID = 3, TrackID = 16 },
                new PlaylistTrack { PlaylistID = 3, TrackID = 18 },
                new PlaylistTrack { PlaylistID = 3, TrackID = 36 },
                new PlaylistTrack { PlaylistID = 3, TrackID = 37 }
            );
            modelBuilder.Entity<BuyAlbum>().HasData
            (
                new BuyAlbum
                {
                    BuyAlbumID = 1,
                    UserID = 3, 
                    AlbumID = 1,
                    DateOfBuying = new DateTime(2020, 12, 20, 10, 30, 50),
                    Price = 15
                },
                new BuyAlbum
                {
                    BuyAlbumID = 2,
                    UserID = 3,
                    AlbumID = 3,
                    DateOfBuying = new DateTime(2020, 12, 23, 11, 24, 10),
                    Price = 10
                }
            );
        }
    }
}


