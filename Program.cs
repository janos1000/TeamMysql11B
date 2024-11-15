using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasketTeam
{
    internal class Program
    {
        public static connect conn = new connect();
        public static void GetAllData()
        {
            conn.Connection.Open();

            string sql = "SELECT * FROM `Player`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            do 
            {
                var player = new
                {
                    Id = dr.GetInt32(0),
                    Name = dr.GetString(1),
                    Height = dr.GetInt32(2),
                    Weight = dr.GetInt32(3),
                    CreatedTime = dr.GetDateTime(4)
                };
            

            Console.WriteLine($"Játékos adatok: {player.Name},{player.Height},{player.Weight}");
            } while (dr.Read());

            dr.Close();
            conn.Connection.Close();
            
        }
        static void Main(string[] args)
        {
         GetAllData();
        }
    }
}
