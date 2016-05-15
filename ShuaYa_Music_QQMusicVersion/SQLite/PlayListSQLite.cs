using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuaYa_Music_QQMusicVersion.SQLite
{
    public class PlayListSQLite
    {
        private static string db_name = "PlayList.db";
        private static string table_name = "Playlist";
        private static string create_table = "CREATE TABLE IF NOT EXISTS " + table_name + " (songname TEXT,singername TEXT,songid TEXT,albumpic_small TEXT,albumpic_big TEXT);";
        private static string get_all = "SELECT * FROM " + table_name + " ;";
        private static string insert = "INSERT INTO " + table_name + " VALUES(?,?,?,?,?);";
        private static string delete = "DELETE FROM " + table_name + " WHERE songname = ?;";

        static SQLiteConnection connection = new SQLiteConnection(db_name);

        public static void Add_New_Music(Models.PlayMusic playmusic)
        {
            using (var statement = connection.Prepare(create_table))
            {
                statement.Step();
            }
            using (var statement = connection.Prepare(insert))
            {
                statement.Bind(1, playmusic.songname);
                statement.Bind(2, playmusic.singername);
                statement.Bind(3, playmusic.songid);
                statement.Bind(4, playmusic.albumpic_small);
                statement.Bind(5, playmusic.albumpic_big);
                statement.Step();
            }
        }

        public static ObservableCollection<Models.PlayMusic> Get_Musiclist()
        {
            using (var statement = connection.Prepare(create_table))
            {
                statement.Step();
            }
            using (var statement = connection.Prepare(get_all))
            {
                long row_count = statement.Connection.LastInsertRowId();
                ObservableCollection<Models.PlayMusic> playmusiclist = new ObservableCollection<Models.PlayMusic>();
                Models.PlayMusic playmusic = new Models.PlayMusic();
                SQLiteResult result = statement.Step();
                if (SQLiteResult.ROW == result)
                {
                    for (int i = 0; i < row_count; i++)
                    {
                        try
                        {
                            playmusic = new Models.PlayMusic();
                            playmusic.songname = statement[0].ToString();
                            playmusic.singername = statement[1].ToString();
                            playmusic.songid = statement[2].ToString();
                            playmusic.albumpic_small = statement[3].ToString();
                            playmusic.albumpic_big = statement[4].ToString();
                            playmusiclist.Add(playmusic);
                            statement.Step();
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                }
                return playmusiclist;
            }
        }

        public static void Del_Old_Music(Models.PlayMusic playmusic)
        {
            using (var statement = connection.Prepare(create_table))
            {
                statement.Step();
            }
            using (var statement = connection.Prepare(delete))
            {
                statement.Bind(1, playmusic.songname);
                statement.Step();
            }
        }
    }
}
