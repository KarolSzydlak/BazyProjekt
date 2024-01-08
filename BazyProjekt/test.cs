using BazyProjekt.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt
{
    internal class test
    {
        static void Main(string[] args)
        {
            var sql = "select pg_backend_pid();";
            var cs = @"User ID=szymon;Password=NHY3ooK9arUzQuIt;Host=frog01.mikr.us;Port=20960;Database=eventsdb";

            var con = new NpgsqlConnection(cs);
             con.Open();
             /*var cmd = new NpgsqlCommand(sql, con);
             Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();

             while (rdr.Read())
             {
                 Console.WriteLine(rdr.GetInt32(0));
             }
             Console.ReadLine();*/
            //String name = client.Username;
            String idCheck = "SELECT id_user FROM PASSWD WHERE username = 'user'";
            //string login = "SELECT register('t','1234');";
            string login = "INSERT INTO comments(id_event, content, id_user) VALUES (36, 'swietna sprawa', 7);";
            Boolean l = true;
            //pid check
            int pid = 2000;
            String name = "a";
            var cmd = new NpgsqlCommand(login, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                l = rdr.GetBoolean(0);
                //pid = rdr.GetInt32(0);
            }
            //Console.ReadLine();
            Console.WriteLine(l);
            int a = 1;

        }

    }
}
