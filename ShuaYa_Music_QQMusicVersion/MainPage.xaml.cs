using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace ShuaYa_Music_QQMusicVersion
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Theme.App_Theme theme = new Theme.App_Theme();
        ViewModels.MainPageViewModel viewmodel = new ViewModels.MainPageViewModel();
        public static MainPage mainpage;
        Api.QQMusic_Apis Api = new ShuaYa_Music_QQMusicVersion.Api.QQMusic_Apis();

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = viewmodel;
            mainpage = this;
            viewmodel.PlayMessage = new ViewModels.PlayMusicViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.New)
            {
                splitview_pane_grid.Background = theme.App_Theme_Color;
                splitview.PaneBackground = theme.App_Theme_Color;
                Title_Rp.Background = theme.App_Theme_Color;
                But_Rp.Background = theme.App_Theme_Color;
                viewmodel.Page_Title = "热门榜单";
                //viewmodel.PlayMessage.IsPause = App.Is_Pause = false;
                main_frame.Navigate(typeof(HitsMusicPage));
                play_song_frame.Navigate(typeof(PlayPage));
            }
        }

        private void menu_button_Click(object sender, RoutedEventArgs e)
        {
            splitview.IsPaneOpen = true;
        }

        private void menu_listview_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewmodel.Page_Title = e.ClickedItem as string;
            splitview.IsPaneOpen = false;
            if (viewmodel.Page_Title == "热门榜单")
            {
                main_frame.Navigate(typeof(HitsMusicPage));
            }
            else if (viewmodel.Page_Title == "歌曲搜索")
            {
                main_frame.Navigate(typeof(SearchMusicPage));
            }
        }

        public void Play_Music(Models.PlayMusic playmusic)
        {
            viewmodel.PlayMusic = playmusic;
            string api = Api.play_song_url;
            api = api.Replace("{0}", viewmodel.PlayMusic.songid);
            mediaelement.Source = new Uri(api);
            PlaySong.Icon = new SymbolIcon(Symbol.Pause);
            viewmodel.PlayMessage.IsPause = App.Is_Pause = false;
            SQLite.PlayListSQLite.Add_New_Music(viewmodel.PlayMusic);
            PlayPage.playpage.PlayMusic(viewmodel.PlayMusic);
            mediaelement.Play();
        }

        private void LastSong_Click(object sender, RoutedEventArgs e)
        {
            LastSong_Method();
        }

        public void LastSong_Method()
        {
            viewmodel.PlayList = SQLite.PlayListSQLite.Get_Musiclist();
            for (int i = 0; i < viewmodel.PlayList.Count; i++)
            {
                if (viewmodel.PlayMusic.songname == viewmodel.PlayList[i].songname && i != 0)
                {
                    Play_Music(viewmodel.PlayList[i - 1]);
                    break;
                }
            }
        }

        private void PlaySong_Click(object sender, RoutedEventArgs e)
        {
            PlaySong_Method();
        }

        public void PlaySong_Method()
        {
            if (App.Is_Pause == true)
            {
                PlayPage.playpage.PlaySong_Method();
                PlaySong.Icon = new SymbolIcon(Symbol.Pause);
                mediaelement.Play();
                viewmodel.PlayMessage.IsPause = App.Is_Pause = false;
            }
            else if (App.Is_Pause == false)
            {
                if (mediaelement.CanPause == true)
                {
                    PlayPage.playpage.PlaySong_Method();
                    PlaySong.Icon = new SymbolIcon(Symbol.Play);
                    mediaelement.Pause();
                    viewmodel.PlayMessage.IsPause = App.Is_Pause = true;
                }
            }
        }

        private void NextSong_Click(object sender, RoutedEventArgs e)
        {
            NextSong_Method();
        }

        public void NextSong_Method()
        {
            viewmodel.PlayList = SQLite.PlayListSQLite.Get_Musiclist();
            for (int i = 0; i < viewmodel.PlayList.Count; i++)
            {
                if (viewmodel.PlayMusic.songname == viewmodel.PlayList[i].songname && i != (viewmodel.PlayList.Count - 1))
                {
                    Play_Music(viewmodel.PlayList[i + 1]);
                    break;
                }
            }
        }

        private void playlist_but_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.PlayList = SQLite.PlayListSQLite.Get_Musiclist();
        }

        private void list_play_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton appbut = e.OriginalSource as AppBarButton;
            Models.PlayMusic playmusic = appbut.DataContext as Models.PlayMusic;
            Play_Music(playmusic);
        }

        private void list_delete_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton appbut = e.OriginalSource as AppBarButton;
            Models.PlayMusic playmusic = appbut.DataContext as Models.PlayMusic;
            SQLite.PlayListSQLite.Del_Old_Music(playmusic);
            viewmodel.PlayList = SQLite.PlayListSQLite.Get_Musiclist();
        }
    }
}
