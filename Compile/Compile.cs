using Interface;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Goal.Compile
{
    public static class Compile
    {
        private static GCompile compile = new GCompile();
        public static GCompile Add(string table, Object obj)
        {
            return compile.Add(table, obj);
        }
        public static GCompile Remove()
        {
            return null;
        }
    }

    public class GCompile
    {
        public enum ActionType
        {
            Insert
        }
        public ActionType actionType { get; set; }
        public bool Cond { get; set; }
        public bool RetList { get; set; }
        private string Query { get; set; }
        public GCompile Add(string table, Object obj)
        {
            try
            {
                Query = string.Empty;
                var fields = obj.GetType().GetProperties()
                    .Select(x => x.GetCustomAttribute<CompileFinder>())
                    .Where(x => !string.IsNullOrEmpty(x.ToString()) && !x.IsDefaultAttribute()).Select(x => x.CompileName).ToList();
                JObject body = JObject.FromObject(obj);
                List<string> values = new List<string>();
                List<string> _fields = new List<string>();
                int i = 0;
                foreach (JProperty item in (JToken)body)
                {
                    if (!string.IsNullOrEmpty(item.Value.ToString()))
                    {
                        if (int.TryParse((string)item.Value, out int e))
                        {
                            if (e != 0)
                            {
                                values.Add(item.Value.ToString());
                                _fields.Add(fields[i]);
                            }
                        }
                        else
                        {
                            if (!DateTime.TryParse((string)item.Value, out DateTime t) &&
                                !double.TryParse((string)item.Value, out double d))
                                values.Add("'" + item.Value + "'");
                            else
                                values.Add(item.Value.ToString());
                            _fields.Add(fields[i]);
                        }
                    }
                    ++i;
                }
                Query = "INSERT INTO " + table + " (" + (string.Join(", ", _fields)).ToUpper() + ") VALUES(" + (string.Join(", ", values)) + ")";
                actionType = ActionType.Insert;
                return this;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public GCompile Remove()
        {
            return null;
        }

        public GCompile Edit()
        {
            return null;
        }

        public GCompile To()
        {
            return null;
        }

        public GCompile Change()
        {
            return null;
        }

        public GCompile Get()
        {
            return null;
        }

        public GCompile If(int i)
        {
            return null;
        }

        public void Save()
        {
            try
            {
                var connection = new Config.Config().getAuth().Connection();
                MySqlCommand cmd = connection.CreateCommand();
                connection.Open();
                switch (actionType)
                {
                    case ActionType.Insert:
                        cmd.CommandText = Query;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
