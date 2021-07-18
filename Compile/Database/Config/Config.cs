using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json;

namespace Config
{
    public class Config
    {
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public Config getAuth()
        {
            using (StreamReader r = new StreamReader("..\\Compile\\Config.json"))
            {
                return JsonConvert.DeserializeObject<Config>(r.ReadToEnd());
            }   
        }
        public MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection("" +
            "server=" + Host + ";" +
            "database=" + Database + ";" +
            "uid=" + User + ";" +
            "pwd=" + Password + "");
            return conn;
        }
    }
}

