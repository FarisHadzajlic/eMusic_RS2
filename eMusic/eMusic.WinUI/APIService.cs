using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eMusic.Model;
using System.Threading.Tasks;
using System.Windows.Forms;
using eMusic.Model.Request;

namespace eMusic.WinUI
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiUrl}/User/Authenticate";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<MUser>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(MUser);
            }
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.ApiUrl}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.ApiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {     
            try
            {
                var url = $"{Properties.Settings.Default.ApiUrl}/{_route}";

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

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
        public async Task<T> Update<T>(int ID, object request)
        {            
            try
            {
                var url = $"{Properties.Settings.Default.ApiUrl}/{_route}/{ID}";

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

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
        public async Task<bool> Delete<T>(int ID)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiUrl}/{_route}/{ID}";

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

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public async Task<T> GetTracks<T>(int ID, TrackSearchRequest search)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiUrl}/{_route}/{ID}/Tracks";

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

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
