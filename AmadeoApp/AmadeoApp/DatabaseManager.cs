using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AmadeoApp
{
    public class DatabaseManager
    {
        public static Dictionary<string, string> GetDatabase()
        {
            string fileName = @"C:\amadeo_helpdesk\AmadeoHelper\AmadeoApp\IdFiles\ConnectionStringList.json";
            var databases = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(fileName));        
            return databases;

        }
        public Dictionary<string, string> Databases { get; set; } = GetDatabase();

        public List<string> ExecuteForLocalMPShop(string query)
        {
            List<string> listResult = new List<string>();
            foreach (var database in Databases)
            {
                if (database.Key != "MP_CENTRALA")
                {
                    using var con = new NpgsqlConnection(database.Value);
                    con.Open();
                    var sql = query;
                    using var cmd = new NpgsqlCommand(sql, con);
                    var result = cmd.ExecuteNonQuery();
                    listResult.Add(result.ToString());
                }
            }
            return listResult;
        }
        public string UpdateForOneDatabase(string query, string Db)
        {                       
                    using var con = new NpgsqlConnection(Databases[Db]);
                    con.Open(); 
                    using var cmd = new NpgsqlCommand(query, con);
                    var result = cmd.ExecuteNonQuery();
                   return $"Zaktualizowano: {result} dla {Db}";
        }
        





        




    }
}
