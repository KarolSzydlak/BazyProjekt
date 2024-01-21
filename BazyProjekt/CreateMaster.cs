using BazyProjekt.Entities;
using BazyProjekt.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyProjekt
{
    public partial class CreateMaster : Form
    {
        String name;
        Int32 id_user;
        NpgsqlConnection con;
        Int32 id_city, id_street, apartment_nr, building_nr;
        List<String> cities, streets;
        BaseRepository repository;
        public CreateMaster(String name, Int32 id_user)
        {
            this.name = name;
            this.id_user = id_user;
            repository = new BaseRepository();
            cities = new List<string>();
            streets = new List<String>();
            var cs = @"User ID=szymon;Password=NHY3ooK9arUzQuIt;Host=frog01.mikr.us;Port=20960;Database=eventsdb";
            con = new NpgsqlConnection(cs);
            InitializeComponent();
            fillboxes();
        }
        public void fillboxes()
        {
            con.Open();
            cities = repository.getCities(cities, con);
            con.Close();
            //
            con.Open();
            streets = repository.getStreets(streets, con);
            con.Close();
            cityBox.Items.Add("");
            streetBox.Items.Add("");
            for (int i = 0; i < cities.Count; i++)
            {
                cityBox.Items.Add(cities[i]);
            }
            for (int i = 0; i < streets.Count; i++)
            {
                streetBox.Items.Add(streets[i]);
            }
            streetBox.SelectedIndex = 1;
            cityBox.SelectedIndex = 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            id_city = cityBox.SelectedIndex+1;
            id_street = streetBox.SelectedIndex+1;
            apartment_nr = (int)numericUpDown2.Value;
            building_nr = (int)numericUpDown1.Value;
            con.Open();
            bool addressC = repository.createAddress(id_city, id_street, apartment_nr, building_nr, con);
            con.Close();
            con.Open();
            int addr = repository.getAddressId(id_city, id_street, apartment_nr, building_nr, con);
            con.Close();
            if (addressC&&addr>-1)
            {
                con.Open();
                repository.createMastermind(name,addr,id_user,con);
                con.Close();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
