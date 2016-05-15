using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class SearchMusicPage : Page
    {

        ViewModels.SearchMusicViewModel viewmodel = new ViewModels.SearchMusicViewModel();
        JsonToObiect.Json_To_Object jto = new JsonToObiect.Json_To_Object();
        Api.QQMusic_Apis Api = new ShuaYa_Music_QQMusicVersion.Api.QQMusic_Apis();
        Theme.App_Theme theme = new Theme.App_Theme();

        public SearchMusicPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            this.DataContext = viewmodel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.New)
            {
                viewmodel.Can_Go_Last = false;
                viewmodel.Can_Go_Next = false;
            }
            viewmodel.Cur_Page = App.searchpage_page = 0;
        }

        private async void autosuggestbox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string api;
            string json = "";

            App.searchpage_page = 1;
            api = Api.search_songs;
            api = api.Replace("{0}", autosuggestbox.Text);
            api = api.Replace("{1}", App.searchpage_page.ToString());
            json = await HttpRequest.SearchMusic_Request.Request(api);
            json = json.Replace("callback(", "");
            json = json.Remove(json.Length - 1);
            JsonToObiect.Json_To_Object.SearchMusic_To_Object(json);
            if (App.search_viewmodel.Search_Music.Count < 20)
            {
                viewmodel.Can_Go_Next = false;
                viewmodel.Can_Go_Last = false;
                viewmodel.Search_Music = App.search_viewmodel.Search_Music;
            }
            else
            {
                viewmodel.Can_Go_Next = true;
                viewmodel.Can_Go_Last = false;
                viewmodel.Search_Music = App.search_viewmodel.Search_Music;
                App.searchpage_page = 1;
            }
            viewmodel.Cur_Page = App.searchpage_page;
        }

        private async void Last_Click(object sender, RoutedEventArgs e)
        {
            if (viewmodel.Can_Go_Last == true)
            {
                string api;
                string json = "";

                App.searchpage_page--;
                api = Api.search_songs;
                api = api.Replace("{0}", autosuggestbox.Text);
                api = api.Replace("{1}", App.searchpage_page.ToString());
                json = await HttpRequest.SearchMusic_Request.Request(api);
                json = json.Replace("callback(", "");
                json = json.Remove(json.Length - 1);
                JsonToObiect.Json_To_Object.SearchMusic_To_Object(json);
                viewmodel.Search_Music = App.search_viewmodel.Search_Music;
                if (App.searchpage_page == 1)
                {
                    viewmodel.Can_Go_Last = false;
                }
            }
            viewmodel.Cur_Page = App.searchpage_page;
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            if (viewmodel.Can_Go_Next == true)
            {
                string api;
                string json = "";

                App.searchpage_page++;
                api = Api.search_songs;
                api = api.Replace("{0}", autosuggestbox.Text);
                api = api.Replace("{1}", App.searchpage_page.ToString());
                json = await HttpRequest.SearchMusic_Request.Request(api);
                json = json.Replace("callback(", "");
                json = json.Remove(json.Length - 1);
                JsonToObiect.Json_To_Object.SearchMusic_To_Object(json);
                if (App.search_viewmodel.Search_Music.Count < 20)
                {
                    viewmodel.Can_Go_Next = false;
                    viewmodel.Search_Music = App.search_viewmodel.Search_Music;
                }
                else
                {
                    viewmodel.Can_Go_Next = true;
                    viewmodel.Search_Music = App.search_viewmodel.Search_Music;
                }
                viewmodel.Can_Go_Last = true;
            }
            viewmodel.Cur_Page = App.searchpage_page;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton appbut = e.OriginalSource as AppBarButton;
            Models.PlayMusic playmusic = new Models.PlayMusic();
            Models.SearchMusic searchmusic = appbut.DataContext as Models.SearchMusic;
            playmusic.singername = searchmusic.singername;
            playmusic.songid = searchmusic.songid.ToString();
            playmusic.songname = searchmusic.songname;
            playmusic.albumpic_small = searchmusic.albumpic_small;
            playmusic.albumpic_big = searchmusic.albumpic_big;
            MainPage.mainpage.Play_Music(playmusic);
        }

        private async void download_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton appbut = e.OriginalSource as AppBarButton;
            Models.DownloadMusic downloadmusic = new Models.DownloadMusic();
            Models.SearchMusic searchmusic = appbut.DataContext as Models.SearchMusic;
            downloadmusic.singername = searchmusic.singername;
            downloadmusic.songid = searchmusic.songid.ToString();
            downloadmusic.songname = searchmusic.songname;
            var dig = new MessageDialog("请耐心等待", "下载开始");
            var btnOk = new UICommand("确定");
            dig.Commands.Add(btnOk);
            var result = await dig.ShowAsync();
            if (null != result && result.Label == "确定")
            {
                Download.Download_Music.Download(downloadmusic);
            }
        }
    }

    public class Cur_Page_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value.ToString() != "0")
            {
                string result = "";
                result = "第" + value.ToString() + "页，共" + App.total_page + "页";
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
