using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class HitsMusicPage : Page
    {

        ViewModels.HitsMusicViewModel viewmodel = new ViewModels.HitsMusicViewModel();
        JsonToObiect.Json_To_Object jto = new JsonToObiect.Json_To_Object();
        Api.QQMusic_Apis Api = new ShuaYa_Music_QQMusicVersion.Api.QQMusic_Apis();
        Theme.App_Theme theme = new Theme.App_Theme();

        public HitsMusicPage()
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
                First_Step();
            }
        }

        public async void First_Step()
        {
            string api;
            string json = "";

            //获取今日热门
            api = Api.hit_songs;
            api = api.Replace("{0}", "26");
            json = await HttpRequest.HitMusic_Requset.Get_Requset_Response(api);
            viewmodel.Today_Hit_Music = JsonToObiect.Json_To_Object.HitMusic_To_Object(json, 51);

            //获取内地热门
            api = Api.hit_songs;
            api = api.Replace("{0}", "5");
            json = await HttpRequest.HitMusic_Requset.Get_Requset_Response(api);
            viewmodel.Cn_Hit_Music = JsonToObiect.Json_To_Object.HitMusic_To_Object(json, 51);

            //获取港台热门
            api = Api.hit_songs;
            api = api.Replace("{0}", "6");
            json = await HttpRequest.HitMusic_Requset.Get_Requset_Response(api);
            viewmodel.Tw_Hit_Music = JsonToObiect.Json_To_Object.HitMusic_To_Object(json, 51);

            //获取韩国热门
            api = Api.hit_songs;
            api = api.Replace("{0}", "16");
            json = await HttpRequest.HitMusic_Requset.Get_Requset_Response(api);
            viewmodel.Kr_Hit_Muisc = JsonToObiect.Json_To_Object.HitMusic_To_Object(json, 51);

            //获取日本热门
            api = Api.hit_songs;
            api = api.Replace("{0}", "17");
            json = await HttpRequest.HitMusic_Requset.Get_Requset_Response(api);
            viewmodel.Jp_Hit_Music = JsonToObiect.Json_To_Object.HitMusic_To_Object(json, 18);

            App.hit_viewmodel = viewmodel;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton appbut = e.OriginalSource as AppBarButton;
            Models.PlayMusic playmusic = new Models.PlayMusic();
            Models.HitsMusic hitmusic = appbut.DataContext as Models.HitsMusic;
            playmusic.singername = hitmusic.singername;
            playmusic.songid = hitmusic.songid;
            playmusic.songname = hitmusic.songname;
            playmusic.albumpic_small = hitmusic.albumpic_small;
            playmusic.albumpic_big = hitmusic.albumpic_big;
            MainPage.mainpage.Play_Music(playmusic);
        }

        private async void download_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton appbut = e.OriginalSource as AppBarButton;
            Models.DownloadMusic downloadmusic = new Models.DownloadMusic();
            Models.HitsMusic hitmusic = appbut.DataContext as Models.HitsMusic;
            downloadmusic.singername = hitmusic.singername;
            downloadmusic.songid = hitmusic.songid;
            downloadmusic.songname = hitmusic.songname;
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
}
