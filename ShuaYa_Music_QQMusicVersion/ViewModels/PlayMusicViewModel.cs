using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.ViewModels
{
    public class PlayMusicViewModel : BaseViewModel
    {
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

        private bool _ispause;
        public bool IsPause
        {
            get
            {
                return _ispause;
            }
            set
            {
                _ispause = value;
                RaisePropertyChanged("IsPause");
            }
        }

        private int _playtime;
        public int PlayTime
        {
            get
            {
                return _playtime;
            }
            set
            {
                _playtime = value;
                RaisePropertyChanged("PlayTime");
            }
        }

        private bool _can_play_last;
        public bool Can_Play_Last
        {
            get
            {
                return _can_play_last;
            }
            set
            {
                _can_play_last = value;
                RaisePropertyChanged("Can_Play_Last");
            }
        }

        private bool _can_play_next;
        public bool Can_Play_Next
        {
            get
            {
                return _can_play_next;
            }
            set
            {
                _can_play_next = value;
                RaisePropertyChanged("Can_Play_Next");
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
