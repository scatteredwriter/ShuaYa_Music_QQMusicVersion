using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuaYa_Music_QQMusicVersion.Models;

namespace ShuaYa_Music_QQMusicVersion.ViewModels
{
    public class HitsMusicViewModel : BaseViewModel
    {
        private ObservableCollection<Models.HitsMusic> _today;
        public ObservableCollection<Models.HitsMusic> Today_Hit_Music
        {
            get
            {
                return _today;
            }
            set
            {
                _today = value;
                RaisePropertyChanged("Today_Hit_Music");
            }
        }

        private ObservableCollection<Models.HitsMusic> _cn;
        public ObservableCollection<Models.HitsMusic> Cn_Hit_Music
        {
            get
            {
                return _cn;
            }
            set
            {
                _cn = value;
                RaisePropertyChanged("Cn_Hit_Music");
            }
        }

        private ObservableCollection<Models.HitsMusic> _tw;
        public ObservableCollection<Models.HitsMusic> Tw_Hit_Music
        {
            get
            {
                return _tw;
            }
            set
            {
                _tw = value;
                RaisePropertyChanged("Tw_Hit_Music");
            }
        }

        private ObservableCollection<Models.HitsMusic> _kr;
        public ObservableCollection<Models.HitsMusic> Kr_Hit_Muisc
        {
            get
            {
                return _kr;
            }
            set
            {
                _kr = value;
                RaisePropertyChanged("Kr_Hit_Music");
            }
        }

        private ObservableCollection<Models.HitsMusic> _jp;
        public ObservableCollection<Models.HitsMusic> Jp_Hit_Music
        {
            get
            {
                return _jp;
            }
            set
            {
                _jp = value;
                RaisePropertyChanged("Jp_Hit_Music");
            }
        }
    }
}
