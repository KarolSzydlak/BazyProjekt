using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyProjekt.Repositories
{
    internal class AdminRepository : BaseRepository
    {
        private Boolean addCity(String name, NpgsqlConnection con)
        {
            Boolean result = false;
            int rowsAffected;
            String ins = "INSERT INTO city(name) VALUES('" + name + "');";
            var cmd = new NpgsqlCommand(ins, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if(rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        private Boolean deleteCity(String name, NpgsqlConnection con)
        {
            Boolean result = false;
            int rowsAffected;
            String ins = "DELETE FROM city WHERE name = '" + name +"';";
            var cmd = new NpgsqlCommand(ins, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        private Boolean addStreet(String name, NpgsqlConnection con)
        {
            Boolean result = false;
            int rowsAffected;
            String ins = "INSERT INTO street(name) VALUES('" + name + "');";
            var cmd = new NpgsqlCommand(ins, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        private Boolean deleteStreet(String name, NpgsqlConnection con)
        {
            Boolean result = false;
            int rowsAffected;
            String ins = "DELETE FROM street WHERE name = '" + name + "';";
            var cmd = new NpgsqlCommand(ins, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        //Zmienia atrybutu active alterType określa czy konto ma byc aktywowane czy deaktywowane////
        private Boolean alterUser(String name, NpgsqlConnection con, bool alterType)
        {
            Boolean result = false;
            int rowsAffected;
            String upd = "UPDATE passwd SET active = " + alterType + "WHERE username = '" + name + "';";
            var cmd = new NpgsqlCommand(upd, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
        private Boolean addCategory(String name, NpgsqlConnection con)
        {
            Boolean result = false;
            int rowsAffected;
            String upd = "INSERT INTO category(name) VALUES('" + name + "');";
            var cmd = new NpgsqlCommand(upd, con);
            rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                result = true;
            }
            return result;
        }
    }
}

