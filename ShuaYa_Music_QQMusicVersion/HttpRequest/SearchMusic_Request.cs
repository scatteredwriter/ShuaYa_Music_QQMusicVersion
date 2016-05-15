using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.HttpRequest
{
    public class SearchMusic_Request
    {
        public static async Task<string> Request(string uri)
        {
            string result;
            HttpClient httpclient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await httpclient.GetAsync(uri);
                result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
