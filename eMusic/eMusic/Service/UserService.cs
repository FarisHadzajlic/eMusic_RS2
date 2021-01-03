using AutoMapper;
using eMusic.Database;
using eMusic.Interface;
using eMusic.Model;
using eMusic.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eMusic.Service
{
    public class UserService : CRUDService<MUser, UserSearchRequest, User, UserUpsertRequest, UserUpsertRequest>, IUserService
    {
        private readonly eMusicContext _context;
        private readonly IMapper _mapper;
        public UserService(eMusicContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async override Task<List<MUser>> Get(UserSearchRequest search)
        {
            var query = _context.Users.Include(x => x.UserRoles).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                query = query.Where(x => x.Username.ToLower().StartsWith(search.Username.ToLower()));
            }
            var list = await query.ToListAsync();
            return _mapper.Map<List<MUser>>(list);
        }

        public override async Task<MUser> GetById(int ID)
        {
            var entity = await _context.Set<User>()
                .Where(i => i.UserID == ID)
                .Include(i => i.UserRoles)
                .SingleOrDefaultAsync();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<MUser> Insert(UserUpsertRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match!");
            }

            var entity = _mapper.Map<User>(request);
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            foreach (var roleID in request.Roles)
            {
                var role = new UserRole()
                {
                    UserID = entity.UserID,
                    RoleID = roleID
                };

                await _context.UserRoles.AddAsync(role);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<MUser> Update(int ID, UserUpsertRequest request)
        {
            var entity = _context.Users.Find(ID);

            _context.Users.Attach(entity);
            _context.Users.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new Exception("Passwords do not match!");
                }

                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }

            foreach (var RoleID in request.Roles)
            {
                var userRole = await _context.UserRoles
                    .Where(i => i.RoleID == RoleID && i.UserID == ID)
                    .SingleOrDefaultAsync();

                if (userRole == null)
                {
                    var newRole = new UserRole()
                    {
                        UserID = ID,
                        RoleID = RoleID
                    };
                    await _context.Set<UserRole>().AddAsync(newRole);
                }
            }

            foreach (var RoleID in request.RolesToDelete)
            {
                var userRole = await _context.UserRoles
                    .Where(i => i.RoleID == RoleID && i.UserID == ID)
                    .SingleOrDefaultAsync();

                if (userRole != null)
                {
                    _context.Set<UserRole>().Remove(userRole);
                }
            }

            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            var user = await _context.Users
                .Include(i => i.UserRoles)
                .ThenInclude(j => j.Role)
                .FirstOrDefaultAsync(i => i.Username == request.Username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, request.Password);

                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<MUser>(user);
                }
            }
            return null;
        }
        public async Task<MUser> Register(UserUpsertRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match!");
            }

            var entity = _mapper.Map<User>(request);
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            var role = await _context.Roles
                .Where(i => i.Name == "User")
                .SingleAsync();

            var userRole = new UserRole()
            {
                UserID = entity.UserID,
                RoleID = role.RoleID
            };

            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();

            return _mapper.Map<MUser>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var entity = await _context.Users.
                Include(i => i.UserRoles).
                Include(i => i.UserTrackReviews).
                Include(i => i.Playlists).
                FirstOrDefaultAsync(i => i.UserID == ID);

            if (entity.UserRoles.Count != 0)
                _context.UserRoles.RemoveRange(entity.UserRoles);
            if (entity.UserTrackReviews.Count != 0)
                _context.UserTrackReviews.RemoveRange(entity.UserTrackReviews);
            if (entity.Playlists.Count != 0)
                _context.Playlists.RemoveRange(entity.Playlists);

            if (entity.Playlists.Count != 0)
            {
                var playlist = await _context.Playlists.Where(i => i.UserID == ID).Include(i => i.PlaylistTracks).FirstOrDefaultAsync();
                _context.PlaylistTracks.RemoveRange(playlist.PlaylistTracks);
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<MTrack>> GetLikedTracks(int ID, TrackSearchRequest request)
        {
            var query = _context.UserLikedTracks
                .Include(i => i.Track)
                .ThenInclude(i => i.Artist)
                .Where(i => i.UserID == ID)
                .AsQueryable();     

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Track.Name.StartsWith(request.Name));
            }

            var list = await query.ToListAsync();
                    
            return _mapper.Map<List<MTrack>>(list.Select(i => i.Track).ToList());
        }
        public async Task<MTrack> InsertLikedTrack(int ID, int TrackID)
        {
            var entity = new UserLikedTrack()
            {
                UserID = ID,
                TrackID = TrackID
            };

            await _context.UserLikedTracks.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MTrack>(entity.Track);
        }
        public async Task<MTrack> DeleteLikedTrack(int ID, int TrackID)
        {
            var entity = await _context.UserLikedTracks
               .Where(i => i.UserID == ID && i.TrackID == TrackID)
               .SingleOrDefaultAsync();
            if (entity != null)
            {
                _context.UserLikedTracks.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<MTrack>(entity);
        }
        public async Task<List<MArtist>> GetLikedArtists(int ID, ArtistSearchRequest request)
        {
            var query = _context.UserLikedArtists
                .Where(i => i.UserID == ID)
                .Select(i => i.Artist)
                .AsQueryable();

            var list = await query.ToListAsync();

            return _mapper.Map<List<MArtist>>(list);
        }
        public async Task<MArtist> InsertLikedArtist(int ID, int ArtistID)
        {
            var entity = new UserLikedArtist()
            {
                UserID = ID,
                ArtistID = ArtistID
            };

            await _context.UserLikedArtists.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MArtist>(entity);
        }
        public async Task<MArtist> DeleteLikedArtist(int ID, int ArtistID)
        {
            var entity = await _context.UserLikedArtists
               .Where(i => i.UserID == ID && i.ArtistID == ArtistID)
               .SingleOrDefaultAsync();
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<MArtist>(entity);
        }
        public async Task<List<MBuyAlbum>> GetUserAlbum(int ID)
        {
            var query = _context.BuyAlbums
                .Include(i => i.Album)
                .ThenInclude(i => i.AlbumTracks)
                .Where(i => i.UserID == ID)
                .AsQueryable();        

            var list = await query.ToListAsync();

            return _mapper.Map<List<MBuyAlbum>>(list);
        }
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

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
