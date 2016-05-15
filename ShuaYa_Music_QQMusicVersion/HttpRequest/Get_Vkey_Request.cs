using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.HttpRequest
{
    public class Get_Vkey_Request
    {

        public static async Task<string> Request()
        {
            string vkey = "";
            string get_vkey_api = "";
            Api.QQMusic_Apis Api = new Api.QQMusic_Apis();
            HttpClient httpclient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();

            get_vkey_api = Api.get_vkey;
            response = await httpclient.GetAsync(new Uri(get_vkey_api));
            Stream stream = await response.Content.ReadAsStreamAsync();
            StreamReader streamreader = new StreamReader(stream);
            vkey = streamreader.ReadToEnd();
            return vkey;
        }
    }
}
