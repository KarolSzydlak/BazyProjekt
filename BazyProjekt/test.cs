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
            //string login = "INSERT INTO comments(id_event, content, id_user) VALUES (36, 'swietna sprawa', 7);";
            string cm = "SELECT * FROM comments WHERE id_event = 30";
            Boolean l = true;
            //pid check
            int pid = 2000;
            String name = "a";
            var cmd = new NpgsqlCommand(cm, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            int idc, ide, idu;
            idc = ide = idu = 0;
            string cont =" ";
            while (rdr.Read())
            {
                idc = rdr.GetInt32(0);
                ide = rdr.GetInt32(1);
                cont = rdr.GetString(2);
                idu = rdr.GetInt32(3);
                Console.WriteLine(idc);
                Console.WriteLine(ide);
                Console.WriteLine(cont);
                Console.WriteLine(idu);
            }
            //Console.ReadLine();
            
            int a = 1;

        }

    }
}
