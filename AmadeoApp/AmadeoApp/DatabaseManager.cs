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
    internal class DatabaseManager
    {
        //Dictionary przechowuje connection stringi + podpisani klienci.
        //Dictionary<string, string> _connections; => _connections["PimLevatianZodiak1"]
        //wczytaj z pliku ten dictionary albo postac json i wtedy desrializacja albo czytaj linia po linii i wrzucaj do tego dictionary
        public static Dictionary<string, string> GetDatabase()
        {
            string fileName = @"C:\amadeo_helpdesk\AmadeoHelper\AmadeoApp\IdFiles\ConnectionStringList.json";
            var databases = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(fileName));        
            return databases;

        }

       Dictionary<string, string> databases = GetDatabase();

        public void ExecuteQueryOnDB()
        {
            foreach (var database in databases)
            {
                using var con = new NpgsqlConnection(database.Value);
                con.Open();
                var sql = QueryBuilder.UncheckBuffor();
                using var cmd  = new NpgsqlCommand(sql, con);
                var result =cmd.ExecuteNonQuery();
                Console.WriteLine($"Zaktualizowano: {result} dla {database.Key}");
            }
        }





        




    }
}
