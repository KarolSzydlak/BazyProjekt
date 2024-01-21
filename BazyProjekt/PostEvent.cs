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
    public partial class PostEvent : Form
    {
        String name;
        Int32 id_user;
        NpgsqlConnection con;
        Int32 id_category;
        List<String> categories;
        BaseRepository repository;
        DateTime date;
        String description;
        Int32 id_address;
        String dateToPost;
        public PostEvent(Int32 id_org, Int32 id_address)
        {
            var cs = @"User ID=szymon;Password=NHY3ooK9arUzQuIt;Host=frog01.mikr.us;Port=20960;Database=eventsdb";
            con = new NpgsqlConnection(cs);
            categories = new List<String>();
            this.id_user = id_org;
            this.id_address = id_address;
            repository = new BaseRepository();
            InitializeComponent();
            fillboxes();
        }
        public void fillboxes()
        {
            con.Open();
            categories = repository.getCategories(categories, con);
            con.Close();
            for (int i = 0; i < categories.Count; i++)
            {
                categoryBox.Items.Add(categories[i]);
            }
            for (int i = 0; i < categories.Count; i++)
            {
                categoryBox.Items.Add(categories[i]);
            }
            categoryBox.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            description = richTextBox1.Text;
            id_category = categoryBox.SelectedIndex+1;
            name = textBox1.Text;
            con.Open();
            dateToPost = date.ToString("yyyy-MM-dd HH:mm:ss");
            repository.postEvent(name, id_address, dateToPost, id_category, id_user, description, con);
            con.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
