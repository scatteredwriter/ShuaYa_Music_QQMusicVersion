using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace ShuaYa_Music_QQMusicVersion.Theme
{
    /// <summary>
    /// APP主题相关资源
    /// </summary>
    public class App_Theme
    {
        private byte _app_background_A = 255;
        private byte _app_background_B = 68;
        private byte _app_background_G = 176;
        private byte _app_background_R = 44;

        public SolidColorBrush App_Theme_Color
        {
            get
            {
                return new SolidColorBrush(Windows.UI.Color.FromArgb(_app_background_A, _app_background_R, _app_background_G, _app_background_B));
            }
        }
    }
}
