using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShuaYa_Music_QQMusicVersion.Models;

namespace ShuaYa_Music_QQMusicVersion.ViewModels
{
    public class SearchMusicViewModel : BaseViewModel
    {
        private ObservableCollection<Models.SearchMusic> _search_music;
        public ObservableCollection<Models.SearchMusic> Search_Music
        {
            get
            {
                return _search_music;
            }
            set
            {
                _search_music = value;
                RaisePropertyChanged("Search_Music");
            }
        }

        private bool _can_go_next;
        public bool Can_Go_Next
        {
            get
            {
                return _can_go_next;
            }
            set
            {
                _can_go_next = value;
                RaisePropertyChanged("Can_Go_Next");
            }
        }

        private bool _can_go_last;
        public bool Can_Go_Last
        {
            get
            {
                return _can_go_last;
            }
            set
            {
                _can_go_last = value;
                RaisePropertyChanged("Can_Go_Last");
            }
        }

        private int _cur_page;
        public int Cur_Page
        {
            get
            {
                return _cur_page;
            }
            set
            {
                _cur_page = value;
                RaisePropertyChanged("Cur_Page");
            }
        }
    }
}
