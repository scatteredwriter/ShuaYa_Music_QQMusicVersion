using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.Api
{
    /// <summary>
    /// QQ音乐API
    /// </summary>
    public class QQMusic_Apis
    {
        /// <summary>
        /// 热门榜单接口
        /// </summary>
        public string hit_songs { get; set; } = "http://route.showapi.com/213-4?showapi_appid=18988&showapi_sign=97e528558a9c446eb1b16f629d278dc3&topid={0}";
        /// <summary>
        /// 歌曲搜索接口
        /// </summary>
        public string search_songs { get; set; } = "http://i.y.qq.com/s.music/fcgi-bin/search_for_qq_cp?g_tk=5381&uin=0&format=jsonp&inCharset=utf-8&outCharset=utf-8&notice=0&platform=h5&needNewCode=1&w={0}&zhidaqu=1&catZhida=1&t=0&flag=1&ie=utf-8&sem=1&aggr=0&perpage=20&n=20&p={1}&remoteplace=txt.mqq.all&_=1460982060643";
        /// <summary>
        /// 专辑图片接口
        /// </summary>
        public string album_img { get; set; } = "http://i.gtimg.cn/music/photo/mid_album_{0}/{1}/{2}/{3}.jpg";
        /// <summary>
        /// 歌曲播放接口
        /// </summary>
        public string play_song_url { get; set; } = "http://ws.stream.qqmusic.qq.com/{0}.m4a?fromtag=46";
        /// <summary>
        /// 获得Vkey接口
        /// </summary>
        public string get_vkey { get; set; } = "http://base.music.qq.com/fcgi-bin/fcg_musicexpress.fcg?json=3&guid=3449771088&g_tk=1840524495&hostUin=0&format=jsonp&inCharset=GB2312&outCharset=GB2312&notice=0&platform=yqq&needNewCode=0";
        /// <summary>
        /// 歌曲下载接口
        /// </summary>
        public string download_song_url { get; set; } = "http://cc.stream.qqmusic.qq.com/{0}.mp3?vkey={1}&guid=3449771088&fromtag=27";
    }
}
