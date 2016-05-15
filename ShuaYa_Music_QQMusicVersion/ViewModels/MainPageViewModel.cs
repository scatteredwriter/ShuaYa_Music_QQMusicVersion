using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<string> _menu = new ObservableCollection<string>();
        public ObservableCollection<string> Menu
        {
            get
            {
                _menu.Add("热门榜单");
                _menu.Add("歌曲搜索");
                return _menu;
            }
        }

        private string _page_title;
        public string Page_Title
        {
            get
            {
                return _page_title;
            }
            set
            {
                _page_title = value;
                RaisePropertyChanged("Page_Title");
            }
        }

        private Models.PlayMusic _playmusic;
        public Models.PlayMusic PlayMusic
        {
            get
            {
                return _playmusic;
            }
            set
            {
                _playmusic = value;
                RaisePropertyChanged("PlayMusic");
            }
        }

        private ViewModels.PlayMusicViewModel _playmessage;
        public ViewModels.PlayMusicViewModel PlayMessage
        {
            get
            {
                return _playmessage;
            }
            set
            {
                _playmessage = value;
                RaisePropertyChanged("PlayMessage");
            }
        }

        private ObservableCollection<Models.PlayMusic> _playmusiclist = new ObservableCollection<Models.PlayMusic>();
        public ObservableCollection<Models.PlayMusic> PlayList
        {
            get
            {
                return _playmusiclist;
            }
            set
            {
                _playmusiclist = value;
                RaisePropertyChanged("PlayList");
            }
        }
    }
}
