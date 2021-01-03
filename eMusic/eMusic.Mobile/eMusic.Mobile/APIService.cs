using eMusic.Model;
using eMusic.Model.Request;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eMusic.Mobile
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;

        private string ApiUrl = "http://localhost:61967/api";
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            try
            {
                var url = $"{ApiUrl}/User/Authenticate";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<MUser>();
            }
            catch (FlurlHttpException)
            {
                return default;
            }
        }
        public async Task<MUser> Register(UserUpsertRequest request)
        {
            try
            {
                var url = $"{ApiUrl}/User/Register";
                return await url.PostJsonAsync(request).ReceiveJson<MUser>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }

        public async Task<T> Get<T>(object search)
        {
            try
            {
                var url = $"{ApiUrl}/{_route}";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                return default;
            }
        }
        public async Task<T> GetById<T>(object ID)
        {
            var url = $"{ApiUrl}/{_route}/{ID}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{ApiUrl}/{_route}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> Update<T>(int ID, object request)
        {
            try
            {
                var url = $"{ApiUrl}/{_route}/{ID}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<bool> Delete<T>(int id)
        {
            try
            {
                var url = $"{ApiUrl}/{_route}/{id}";


                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<T> GetTracks<T>(int ID, TrackSearchRequest search)
        {
            try
            {
                var url = $"{ApiUrl}/{_route}/{ID}/Tracks";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> GetAlbums<T>(int id, AlbumSearchRequest search)
        {
            try
            {
                var url = $"{ApiUrl}/{_route}/{id}/Albums";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<List<MTrack>> GetLikedTracks(int ID, TrackSearchRequest search)
        {
            try
            {
                var url = $"{ApiUrl}/User/{ID}/LikedTracks";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<MTrack>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<List<MArtist>> GetLikedArtists(int ID, ArtistSearchRequest search)
        {
            try
            {
                var url = $"{ApiUrl}/User/{ID}/LikedArtists";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<MArtist>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<MTrack> InsertLikedTrack(int ID, int TrackID)
        {
            try
            {
                var url = $"{ApiUrl}/User/{ID}/LikedTrack/{TrackID}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(null).ReceiveJson<MTrack>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<MArtist> InsertLikedArtist(int ID, int ArtistID)
        {
            try
            {
                var url = $"{ApiUrl}/User/{ID}/LikedArtist/{ArtistID}";

                return await url.WithBasicAuth(Username, Password).PostJsonAsync(null).ReceiveJson<MArtist>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<MTrack> DeleteLikedTrack(int id, int TrackID)
        {
            try
            {
                var url = $"{ApiUrl}/User/{id}/LikedTrack/{TrackID}";

                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<MTrack>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<MArtist> DeleteLikedArtist(int id, int ArtistID)
        {
            try
            {
                var url = $"{ApiUrl}/User/{id}/LikedArtist/{ArtistID}";

                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<MArtist>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<List<MBuyAlbum>> GetUserAlbum(int ID)
        {
            try
            {
                var url = $"{ApiUrl}/User/{ID}/UserAlbum";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<MBuyAlbum>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<List<MTrack>> GetRecommandedTracks(int ID)
        {
            try
            {
                var url = $"{ApiUrl}/{_route}/GetRecommendedTracks?UserID={ID}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<List<MTrack>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default;
            }
        }
        public async Task<bool> Remove(int ID, string actionName = null)
        {
            var url = $"{ApiUrl}/{_route}";

            if (actionName != null)
                url += "/" + actionName;

            url += "/" + ID;

            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
        }
    }
}
