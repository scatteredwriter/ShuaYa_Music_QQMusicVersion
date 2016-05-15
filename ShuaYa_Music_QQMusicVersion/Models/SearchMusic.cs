using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.Models
{
    /// <summary>
    /// 搜索歌曲类
    /// </summary>
    public class SearchMusic
    {
        public string albumname { get; set; }//专辑名
        public string albummid { get; set; }//专辑mid
        public string albumpic_big { get; set; }//专辑封面大图
        public string albumpic_small { get; set; }//专辑封面小图

        public string singername { get; set; }//歌手名

        public string songname { get; set; }//歌名
        public int songid { get; set; }//歌曲id
        public string songmid { get; set; }//歌曲mid
    }
}
