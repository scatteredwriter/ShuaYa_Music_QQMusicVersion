using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.JsonToObiect
{
    public class Json_To_Object
    {
        public static ObservableCollection<Models.HitsMusic> HitMusic_To_Object(string json, int i)
        {
            ObservableCollection<Models.HitsMusic> hitmusics = new ObservableCollection<Models.HitsMusic>();
            Models.HitsMusic hitmusic = new Models.HitsMusic();
            try
            {
                JObject jo1 = (JObject)JsonConvert.DeserializeObject(json);
                JObject jo2 = (JObject)jo1["showapi_res_body"];
                JObject jo3 = (JObject)jo2["pagebean"];
                JArray ja1 = (JArray)jo3["songlist"];

                for (int n = 0; n < i; n++)
                {
                    hitmusic = new Models.HitsMusic();
                    try
                    {
                        hitmusic.albumid = ja1[n]["albumid"].ToString();
                        hitmusic.albumpic_big = ja1[n]["albumpic_big"].ToString();
                        hitmusic.albumpic_small = ja1[n]["albumpic_small"].ToString();
                    }
                    catch (Exception)
                    {
                        hitmusic.albumid = "null";
                        hitmusic.albumpic_big = "null";
                        hitmusic.albumpic_small = "null";
                    }

                    hitmusic.songid = ja1[n]["songid"].ToString();
                    hitmusic.songname = ja1[n]["songname"].ToString();

                    hitmusic.url = ja1[n]["url"].ToString();

                    try
                    {
                        hitmusic.singername = ja1[n]["singername"].ToString();
                    }
                    catch (Exception)
                    {
                        hitmusic.singername = "未知";
                    }

                    hitmusics.Add(hitmusic);
                }

                return hitmusics;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SearchMusic_To_Object(string json)
        {
            int num = 0;
            int total_page = 0;
            string api;
            Api.QQMusic_Apis Api = new ShuaYa_Music_QQMusicVersion.Api.QQMusic_Apis();
            ObservableCollection<Models.SearchMusic> searchsongs = new ObservableCollection<Models.SearchMusic>();
            Models.SearchMusic searchsong = new Models.SearchMusic();
            try
            {
                JObject jo1 = (JObject)JsonConvert.DeserializeObject(json);
                JObject jo2 = (JObject)jo1["data"];
                JObject jo3 = (JObject)jo2["song"];
                JArray ja1 = (JArray)jo3["list"];

                total_page = Int32.Parse(jo3["totalnum"].ToString());
                App.total_page = Int32.Parse(((float)total_page / 20).ToString().Substring(0, ((float)total_page / 20).ToString().IndexOf('.'))) + 1;
                if (ja1.Count < 20)
                {
                    num = ja1.Count;
                }
                else
                {
                    num = 20;
                }
                for (int i = 0; i < num; i++)
                {
                    searchsong = new Models.SearchMusic();
                    api = Api.album_img;

                    searchsong.albumname = ja1[i]["albumname"].ToString();
                    searchsong.albummid = ja1[i]["albummid"].ToString();

                    searchsong.albumpic_big = api;
                    searchsong.albumpic_big = searchsong.albumpic_big.Replace("{0}", "300");
                    searchsong.albumpic_big = searchsong.albumpic_big.Replace("{1}", (searchsong.albummid[searchsong.albummid.Length - 2]).ToString());
                    searchsong.albumpic_big = searchsong.albumpic_big.Replace("{2}", (searchsong.albummid[searchsong.albummid.Length - 1]).ToString());
                    searchsong.albumpic_big = searchsong.albumpic_big.Replace("{3}", searchsong.albummid);

                    searchsong.albumpic_small = api;
                    searchsong.albumpic_small = searchsong.albumpic_small.Replace("{0}", "90");
                    searchsong.albumpic_small = searchsong.albumpic_small.Replace("{1}", (searchsong.albummid[searchsong.albummid.Length - 2]).ToString());
                    searchsong.albumpic_small = searchsong.albumpic_small.Replace("{2}", (searchsong.albummid[searchsong.albummid.Length - 1]).ToString());
                    searchsong.albumpic_small = searchsong.albumpic_small.Replace("{3}", searchsong.albummid);

                    JArray ja2 = (JArray)ja1[i]["singer"];
                    searchsong.singername = ja2[0]["name"].ToString();

                    searchsong.songname = ja1[i]["songname"].ToString();

                    searchsong.songid = Convert.ToInt32(ja1[i]["songid"].ToString());
                    searchsong.songmid = ja1[i]["songmid"].ToString();

                    searchsongs.Add(searchsong);
                }
                App.search_viewmodel.Search_Music = searchsongs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Get_Vkey(string json)
        {
            string vkey;
            try
            {
                JObject jo1 = (JObject)JsonConvert.DeserializeObject(json);
                vkey = jo1["key"].ToString();
                return vkey;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
