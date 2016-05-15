using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.HttpRequest
{
    public class HitMusic_Requset
    {
        /// <summary>
        /// 得到热门歌曲的Json
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task<string> Get_Requset_Response(string uri)
        {
            HttpClient httpclient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            string result;
            response = await httpclient.GetAsync(new Uri(uri));
            result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
