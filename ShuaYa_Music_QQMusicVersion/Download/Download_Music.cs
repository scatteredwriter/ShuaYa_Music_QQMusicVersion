using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Popups;

namespace ShuaYa_Music_QQMusicVersion.Download
{
    public class Download_Music
    {

        static string vkey = "";
        static string download_api = "";
        static string songname = "";

        public static async void Download(Models.DownloadMusic downloadmusic)
        {
            StorageFolder downloadpath;
            BackgroundDownloader downloader = new BackgroundDownloader();
            StorageFile filename;

            downloadpath = KnownFolders.MusicLibrary;
            Api.QQMusic_Apis Api = new ShuaYa_Music_QQMusicVersion.Api.QQMusic_Apis();
            vkey = await HttpRequest.Get_Vkey_Request.Request();
            vkey = vkey.Replace("jsonCallback(", "");
            vkey = vkey.Remove(vkey.Length - 2);
            vkey = JsonToObiect.Json_To_Object.Get_Vkey(vkey);
            download_api = Api.download_song_url;
            download_api = download_api.Replace("{0}", downloadmusic.songid);
            download_api = download_api.Replace("{1}", vkey);
            songname = downloadmusic.songname + "-" + downloadmusic.singername + ".mp3";
            songname = songname.Replace("\\", "");
            songname = songname.Replace("/", "");
            songname = songname.Replace(":", "");
            songname = songname.Replace("*", "");
            songname = songname.Replace("?", "");
            songname = songname.Replace("\"", "");
            songname = songname.Replace("<", "");
            songname = songname.Replace(">", "");
            try
            {
                Progress<DownloadOperation> progress_reporter = new Progress<DownloadOperation>(OnProgressHandler);
                filename = await downloadpath.CreateFileAsync(songname, CreationCollisionOption.ReplaceExisting);
                DownloadOperation operation = downloader.CreateDownload(new Uri(download_api), filename);
                await operation.StartAsync().AsTask(progress_reporter);
            }
            catch (Exception)
            {
                var dig = new MessageDialog("请重新尝试", "下载失败");
                var btnOk = new UICommand("确定");
                dig.Commands.Add(btnOk);
                var result = await dig.ShowAsync();
                if (null != result && result.Label == "确定")
                {
                }
            }
        }

        public static async void OnProgressHandler(DownloadOperation operation)//响应传输进度更新
        {
            if (operation.Progress.Status == BackgroundTransferStatus.Completed)
            {
                var dig = new MessageDialog(songname+"已成功下载", "下载成功");
                var btnOk = new UICommand("确定");
                dig.Commands.Add(btnOk);
                var result = await dig.ShowAsync();
                if (null != result && result.Label == "确定")
                {

                }
            }
        }

    }
}
