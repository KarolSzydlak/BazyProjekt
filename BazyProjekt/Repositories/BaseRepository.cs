using BazyProjekt.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt.Repositories
{
    internal class BaseRepository
    {
        
        public void establishCon(NpgsqlConnection con)
        {
            
            var cs = @"User ID=szymon;Password=NHY3ooK9arUzQuIt;Host=frog01.mikr.us;Port=20960;Database=eventsdb";
            con = new NpgsqlConnection(cs);
            con.Open();
        }

        //reg to rejestrowanie zwraca true jesli wpisano rekord do passwd
        public Boolean reg(String username, String passwd, NpgsqlConnection con)
        {
            
            bool result = false;
            // hashowanie hasla przed stringiem???
            String login = "SELECT register('" + username + "','" + passwd + "');";
            var cmd = new NpgsqlCommand(login, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                result = rdr.GetBoolean(0);
                
            }

            rdr.Close();
            return result;
            
        }
        // po logowaniu trzeba utworzyć masterminda przypisanego do klienta aby mógł zamieszczać wydarzenia
        public Client login(String username, String passwd, NpgsqlConnection con)
        {
            Client cl = new Client();
            cl.IsMastermind = false;
            bool result = false;
            // hashowanie hasla przed stringiem???
            String login = "SELECT login('" + username + "','" + passwd + "');";
            var cmd = new NpgsqlCommand(login, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                result = rdr.GetBoolean(0);

            }
            if(result == true)
            {
                cl.Username = username;
                String getAT = "SELECT id_user FROM PASSWD WHERE username = '" + username + "';";
                cmd = new NpgsqlCommand(getAT, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cl.Id = rdr.GetInt32(0);
                }
                String pid = "SELECT pb_backend_pid();";
                cmd = new NpgsqlCommand(pid, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cl.Session_id = rdr.GetInt32(0);
                }
                cl.Logged = true;
            }
            rdr.Close();
            return cl;
        }
        private Boolean postComment(Client cl, Int32 id_event, String content, NpgsqlConnection con)
        {
            if(cl.Logged == false)
            {
                return false;
            }
            bool result = false;
            int rowsAffected = 0;
            String ins = "INSERT INTO comments(id_event, id_user, content) VALUES " +
                "(" + id_event.ToString() + "," + cl.Id.ToString() + ",'" + content + "');";
            var cmd = new NpgsqlCommand(ins, con);
             rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == -1)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
        private Boolean postEvent(Mastermind ms, String name, Int32 id_address, DateTime dt, TimeSpan ts, Int32 category_id,
            Int32 id_org, String description, NpgsqlConnection con)
        {
            bool result = false;
            int rowsAffected = 0;
            String ins = "INSERT INTO events(name, id_address, date, duration, category_id, id_org,description) VALUES " +
                "('" + name + "'," + id_address.ToString() + "," + dt + "," + ts + "," + category_id.ToString() + "," +
                id_org.ToString() + ",'" + description + "');";
            var cmd = new NpgsqlCommand(ins, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == -1)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
        //wyszukiwanie po dacie i miejscu 
        private void searchEvent(List<Event> ev, String name, Int32 id_address, DateTime start, DateTime end,
            TimeSpan duration, Int32 category_id, Int32 id_org, String description, NpgsqlConnection con)
        {
            String res = "Select * FROM events WHERE date < " + "'" + end + "'" + "and date > " + "'" + start + "'" +
                "id_address = " + id_address;
            var cmd = new NpgsqlCommand(res, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Event e = new Event();
                e.Id_event = rdr.GetInt32(0);
                e.Name = rdr.GetString(1);
                e.Id_address = rdr.GetInt32(2);
                e.Date = rdr.GetDateTime(3);
                e.TimeSpan = rdr.GetTimeSpan(4);
                e.Category_id = rdr.GetInt32(5);
                e.Id_org = rdr.GetInt32(6);
                e.Description = rdr.GetString(7);
                ev.Add(e);

            }
            rdr.Close();
        }
        private void loadComments(List<Comment> comments, Int32 id_event, NpgsqlConnection con)
        {
            String ld = "SELECT * FROM comments WHERE id_event = " + id_event + ";";
            var cmd = new NpgsqlCommand(ld, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Comment cm = new Comment();
                cm.Id_comment = rdr.GetInt32(0);
                cm.Id_event = rdr.GetInt32(1);
                cm.Content = rdr.GetString(2);
                cm.Id_user = rdr.GetInt32(3);
                comments.Add(cm);

            }
            rdr.Close();
        }
        //zapisanie wydarzenia
        private Boolean save(Int32 id_user,Int32 id_event, NpgsqlConnection con)
        {
            bool result = false;
            int rowsAffected = 0;
            String ins = "INSERT INTO saved(id_user, id_event) VALUES(" + id_user.ToString() + "," + id_event.ToString() +");";
            var cmd = new NpgsqlCommand(ins, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if(rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        private Boolean deleteSaved(Int32 id_user, Int32 id_event, NpgsqlConnection con)
        {
            bool result = false;
            int rowsAffected = 0;
            String ins = "DELETE FROM saved WHERE id_user = " + id_user.ToString() + " AND id_event = " + id_event.ToString() + ";";
            var cmd = new NpgsqlCommand(ins, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        private Boolean createMastermind(String name, Int32 id_address, Int32 id_user, NpgsqlConnection con)
        {
            bool result = false;
            int rowsAffected = 0;
            String str = "INSERT INTO mastermind(name,id_address,id_user) VALUES('" + name + "'," + id_address + "," + id_user + ");";
            var cmd = new NpgsqlCommand(str, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
