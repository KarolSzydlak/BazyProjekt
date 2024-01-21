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
using System.Security.Cryptography;
using System.Reflection.Emit;
using System.Data;
using System.Windows.Forms;
using Npgsql.Internal.Postgres;

namespace BazyProjekt.Repositories
{
    internal class BaseRepository
    {
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
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
            passwd = GetHashString(passwd);
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
            passwd = GetHashString(passwd);
            // hashowanie hasla przed stringiem???
            String login = "SELECT login('" + username + "','" + passwd + "');";
            var cmd = new NpgsqlCommand(login, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                result = rdr.GetBoolean(0);

            }
            if (result == true)
                cl.Logged = true;
            /*{
                cl.Username = username;
                String getAT = "SELECT id_user FROM PASSWD WHERE username = '" + username + "';";
                cmd = new NpgsqlCommand(getAT, con);
                Npgsql.NpgsqlDataReader pbrd = cmd.ExecuteReader();
                while (pbrd.Read())
                {
                    cl.Id = pbrd.GetInt32(0);
                }
                pbrd.Close();
                String pid = "SELECT pb_backend_pid();";
                cmd = new NpgsqlCommand(pid, con);
                Npgsql.NpgsqlDataReader pidr = cmd.ExecuteReader();
                while (pidr.Read())
                {
                    cl.Session_id = rdr.GetInt32(0);
                }
                cl.Logged = true;
                pidr.Close();
            }*/
            rdr.Close();
            return cl;
        }
        public void logOut(String name, String passwd, NpgsqlConnection con)
        {
            passwd = GetHashString(passwd);
            String lg = "SELECT logout('" + name + "','" + passwd + "');";
            var cmd = new NpgsqlCommand(lg, con);
            cmd.ExecuteNonQuery();
        }
        public Int32 getUserId(String name, NpgsqlConnection con)
        {
            Int32 userId = -1;
            String sel = "SELECT id_user FROM passwd WHERE username = '" + name + "';";
            var cmd = new NpgsqlCommand(sel, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                userId = rdr.GetInt32(0);
            }
            rdr.Close();
            return userId;
        }
        public Boolean postComment(Client cl, Int32 id_event, String content, NpgsqlConnection con)
        {
            if (cl.Logged == false)
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
        public Boolean postEvent(String name, Int32 id_address, String dt, Int32 category_id,
            Int32 id_org, String description, NpgsqlConnection con)
        {
            bool result = false;
            int rowsAffected = 0;
            String ins = "INSERT INTO events(name, id_address, date, category_id, id_org,description) VALUES " +
                "('" + name + "'," + id_address.ToString() + ",'" + dt + "'," + category_id.ToString() + "," +
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
        public void searchEvent(List<Event> ev, String name, Int32 id_address, DateTime start, DateTime end,
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
        public DataTable loadComments(DataTable comments, Int32 id_event, NpgsqlConnection con)
        {
            String ld = "SELECT passwd.username, comments.content FROM comments JOIN passwd ON comments.id_user = passwd.id_user JOIN events " +
                "ON comments.id_event = events.id_event where events.id_event = " + id_event + ";";
            var cmd = new NpgsqlCommand(ld, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DataRow row;
                row = comments.NewRow();
                row["Nazwa użytkownika"] = rdr.GetString(0);
                row["Komentarz"] = rdr.GetString(1);
                comments.Rows.Add(row);

            }
            rdr.Close();
            return comments;
        }
        //zapisanie wydarzenia
        public Boolean save(Int32 id_user, Int32 id_event, NpgsqlConnection con)
        {
            bool result = false;
            int rowsAffected = 0;
            String ins = "INSERT INTO saved(id_user, id_event) VALUES(" + id_user.ToString() + "," + id_event.ToString() + ");";
            var cmd = new NpgsqlCommand(ins, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        public Boolean deleteSaved(Int32 id_user, Int32 id_event, NpgsqlConnection con)
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
        public Boolean createMastermind(String name, Int32 id_address, Int32 id_user, NpgsqlConnection con)
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
        public DataTable FillDG(String name, String mName, String cityName, String catName, DateTime startDate, DateTime endDate,
            NpgsqlConnection con, DataTable dt)
        {
            
            Boolean firstAppend = true;
            String selName = "and events.name = '" + name + "' ";
            String selmName = "and mastermind.name = '" + mName + "' ";
            String selCity = "and city.name = '" + cityName + "' ";
            String selCat = "and category.name = '" + catName + "' ";
            String startDateS = startDate.ToString("yyyy-MM-dd HH:mm:ss");
            String endDateS = endDate.ToString("yyyy-MM-dd HH:mm:ss");

            String sql = "SELECT events.name, mastermind.name,city.name, street.name, address.building_nr, address.apartment_nr, events.date, events.description " +
                    "FROM events JOIN address ON events.id_address = address.id_address " +
                    "JOIN city ON city.id_city = address.id_city " +
                    "JOIN mastermind ON events.id_org = mastermind.id_org " +
                    "JOIN street on address.id_street = street.id_street " +
                    "JOIN category ON events.category_id = category.id_category " +
                    "WHERE date < '" + endDateS + "' and date > '" + startDateS + "' ";

            if (!String.IsNullOrEmpty(name))
            {
                sql += selName;
            }
            if (!String.IsNullOrEmpty(mName))
            {
                sql += selmName;
            }
            if (!String.IsNullOrEmpty(cityName))
            {
                sql += selCity;
            }
            if (!String.IsNullOrEmpty(catName))
            {
                sql += selCat;
            }
            sql += ";";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            DataRow row;
            while (rdr.Read())
            {
                row = dt.NewRow();
                row["Nazwa wydarzenia"] = rdr.GetString(0);
                row["Nazwa organizatora"] = rdr.GetString(1);
                row["Miasto"] = rdr.GetString(2);
                row["Ulica"] = rdr.GetString (3);
                row["Nr. budynku"] = rdr.GetInt32 (4);
                row["Nr. lokalu"] = rdr.GetInt32(5);
                row["Data"] = rdr.GetDateTime(6);
                row["Opis"] = rdr.GetString(7);
                dt.Rows.Add(row);

            }
            return dt;
        }
        public List<String> getCities(List<String> dt, NpgsqlConnection con)
        {
            String sql = "SELECT name FROM city;";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dt.Add(rdr.GetString(0));
            }
            return dt;
        }
        public List<String> getStreets(List<String> dt, NpgsqlConnection con)
        {
            String sql = "SELECT name FROM street;";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dt.Add(rdr.GetString(0));
            }
            return dt;
        }
        public List<String> getCategories(List<String> dt, NpgsqlConnection con)
        {
           
            String sql = "SELECT name FROM category;";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dt.Add(rdr.GetString(0));
            }
            return dt;
        }
        public Int32 getEventId(String eName, String mName, String date, NpgsqlConnection con)
        {
            Int32 eId = -1;
            String sql = "SELECT id_event FROM events JOIN mastermind on events.id_org = mastermind.id_org WHERE " +
                "events.name = '" + eName + "' " + "and mastermind.name = '" + mName + "' and events.date = '" + date + "';";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                eId = rdr.GetInt32(0);
            }
            rdr.Close();
            return eId;
        }
        public Boolean checkMastermind(String name, NpgsqlConnection con)
        {
            String res = null;
            String sql = "SELECT name FROM mastermind WHERE name = '" + name + "';";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                res = rdr.GetString(0);
            }
            rdr.Close();
            if (res == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean checkIfMaster(Int32 id, NpgsqlConnection con)
        {
            String name = null;
            String sql = "SELECT name FROM mastermind WHERE id_user = " + id.ToString() + ";";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr.GetString(0);
            }
            rdr.Close();
            if (name == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean createAddress(Int32 id_city, Int32 id_street, Int32 apartment_id, Int32 building_nr, NpgsqlConnection con)
        {
            bool result = false;
            int rowsAffected = -1;
            String sql = "INSERT INTO address(id_city,id_street,apartment_nr,building_nr) VALUES(" + id_city.ToString() + "," + id_street.ToString() + "," + apartment_id.ToString() + "," + building_nr.ToString() + ");";
            var cmd = new NpgsqlCommand(sql, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        public Int32 getAddressId(Int32 id_city, Int32 id_street, Int32 apartment_id, Int32 building_nr, NpgsqlConnection con)
        {
            int addr = -1;
            String sql = "SELECT id_address from address where id_city = " + id_city.ToString() + " and id_street = " + id_street.ToString() + " and apartment_nr = " + apartment_id.ToString() + " and building_nr = " + building_nr.ToString() + ";";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                addr = rdr.GetInt32(0);
            }
            return addr;
        }
        public Int32 getIdOrg(Int32 id_user, NpgsqlConnection con)
        {
            int addr = -1;
            String sql = "Select id_org FROM passwd join mastermind on mastermind.id_user = passwd.id_user where passwd.id_user = " + id_user.ToString() + ";";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                addr = rdr.GetInt32(0);
            }
            return addr;
        }
        public Int32 getOrgAdd(Int32 id_user, NpgsqlConnection con)
        {
            int addr = -1;
            String sql = "Select id_address FROM passwd join mastermind on passwd.id_user = mastermind.id_user where passwd.id_user = " + id_user.ToString() + ";";
            var cmd = new NpgsqlCommand(sql, con);
            Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                addr = rdr.GetInt32(0);
            }
            return addr;
        }
    }
}

