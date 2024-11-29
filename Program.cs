using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Numerics;
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
        public static void AddNewPlayer(string name, int height, int weight)
        {
            try
            {
                conn.Connection.Open();

                string sql = $"INSERT INTO `player`(`Name`, `Height`, `Weight`) VALUES ('{name}',{height},{weight})";

                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
                cmd.ExecuteNonQuery();

                conn.Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void Deleteplayer(int id)
        {
            conn.Connection.Open();

            string sql = $"DELETE FROM `player` WHERE `id`= {id};";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();

            conn.Connection.Close();
        }
        public static void UpdatePlayer(int id, string name, int height, int weight)
        {
            conn.Connection.Open();

            string sql = $"UPDATE `player` SET ,`Name`='{name}',`Height`= {height},`Weight`= {weight} WHERE `id`= {id};";
            MySqlCommand cmd = new MySqlCommand (sql, conn.Connection);
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Kérem a játékos azonosítót: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Kérem az új nevet: ");
                string name = Console.ReadLine();

                Console.Write("Kérem az új magasságát: ");
                int height = int.Parse(Console.ReadLine());

                Console.Write("Kérem az új súlyát: ");
                int weight = int.Parse(Console.ReadLine());

                UpdatePlayer(id, name, height, weight);
                Console.WriteLine("Sikeres frissítés.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //try
            //{
            //    Console.WriteLine("Kérem a játékos azonosítót a törléshez: ");
            //    int azon = int.Parse(Console.ReadLine());
            //    Deleteplayer(azon);
            //    Console.WriteLine("Sikeres törlés.");

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}


            //GetAllData();

            //try
            //{
            //    Console.Write("Kérem a játékos nevét: ");
            //    string name = Console.ReadLine();
            //    Console.Write("Kérem a játékos magasságát: ");
            //    int height = int.Parse(Console.ReadLine());
            //    Console.Write("Kérem a játékos súlyát: ");
            //    int weight = int.Parse(Console.ReadLine());
            //    AddNewPlayer(name, height, weight);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

        }
    }
}
