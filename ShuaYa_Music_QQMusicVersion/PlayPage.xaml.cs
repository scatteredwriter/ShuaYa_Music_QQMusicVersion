using System;
using System.Collections.Generic;
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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace ShuaYa_Music_QQMusicVersion
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class PlayPage : Page
    {

        public static PlayPage playpage;
        Theme.App_Theme theme = new Theme.App_Theme();
        ViewModels.PlayMusicViewModel viewmodel = new ViewModels.PlayMusicViewModel();

        public PlayPage()
        {
            this.InitializeComponent();
            this.DataContext = viewmodel;
            playpage = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.New)
            {
                albumpic.Visibility = Visibility.Collapsed;
                But_Rp.Background = theme.App_Theme_Color;
                albumpic.Stroke = theme.App_Theme_Color;
                Title_Rp.Background = theme.App_Theme_Color;
                songname_tb.Foreground = theme.App_Theme_Color;
                singername_tb.Foreground = theme.App_Theme_Color;
            }
        }

        public void PlayMusic(Models.PlayMusic playmusic)
        {
            viewmodel.PlayMusic = playmusic;
            albumpic.Visibility = Visibility.Visible;
            viewmodel.IsPause = App.Is_Pause;
            PlaySong.Icon = new SymbolIcon(Symbol.Pause);
        }

        private void LastSong_Click(object sender, RoutedEventArgs e)
        {
            MainPage.mainpage.LastSong_Method();
        }

        private void PlaySong_Click(object sender, RoutedEventArgs e)
        {
            if (App.Is_Pause == true)
            {
                PlaySong.Icon = new SymbolIcon(Symbol.Pause);
                MainPage.mainpage.PlaySong_Method();
                viewmodel.IsPause = App.Is_Pause = false;
            }
            else if (App.Is_Pause == false)
            {
                PlaySong.Icon = new SymbolIcon(Symbol.Play);
                MainPage.mainpage.PlaySong_Method();
                viewmodel.IsPause = App.Is_Pause = true;
            }
        }

        public void PlaySong_Method()
        {
            if (App.Is_Pause == true)
            {
                viewmodel.IsPause = App.Is_Pause = false;
                PlaySong.Icon = new SymbolIcon(Symbol.Pause);
            }
            else if (App.Is_Pause == false)
            {
                viewmodel.IsPause = App.Is_Pause = true;
                PlaySong.Icon = new SymbolIcon(Symbol.Play);
            }
        }

        private void NextSong_Click(object sender, RoutedEventArgs e)
        {
            MainPage.mainpage.NextSong_Method();
        }

        private void playlist_but_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.PlayList = SQLite.PlayListSQLite.Get_Musiclist();
        }

        private void list_play_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton appbut = e.OriginalSource as AppBarButton;
            Models.PlayMusic playmusic = appbut.DataContext as Models.PlayMusic;
            MainPage.mainpage.Play_Music(playmusic);
        }

        private void list_delete_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton appbut = e.OriginalSource as AppBarButton;
            Models.PlayMusic playmusic = appbut.DataContext as Models.PlayMusic;
            SQLite.PlayListSQLite.Del_Old_Music(playmusic);
            viewmodel.PlayList = SQLite.PlayListSQLite.Get_Musiclist();
        }
    }
    public class Songname_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value.ToString() != null || value.ToString() != "")
            {
                string result = value.ToString();
                result = "歌曲：" + result;
                return result;
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class Singername_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value.ToString() != null || value.ToString() != "")
            {
                string result = value.ToString();
                result = "歌手：" + result;
                return result;
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
