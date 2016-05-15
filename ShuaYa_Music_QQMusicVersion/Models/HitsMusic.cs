using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.Models
{
    /// <summary>
    /// 热门歌曲类
    /// </summary>
    public class HitsMusic
    {
        public string albumid { get; set; }//专辑的id

        public string albumpic_small { get; set; }//专辑图片的小图
        public string albumpic_big { get; set; }//专辑图片的大图

        public string singername { get; set; }//歌手名

        public string songid { get; set; }//歌曲id
        public string songname { get; set; }//歌曲名

        public string url { get; set; }//歌曲播放url
    }
}
