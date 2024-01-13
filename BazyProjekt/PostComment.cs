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
    public partial class PostComment : Form
    {
        NpgsqlConnection con;
        BaseRepository repository;
        Int32 id_event;
        Client cl;
        public PostComment(Int32 id_event, Int32 id_user, Boolean logged, String eventName)
        {
            InitializeComponent();
            var cs = @"User ID=szymon;Password=NHY3ooK9arUzQuIt;Host=frog01.mikr.us;Port=20960;Database=eventsdb";
            con = new NpgsqlConnection(cs);
            repository = new BaseRepository();
            this.id_event = id_event;
            cl = new Client();
            cl.Logged = logged;
            cl.Id = id_user;
            label3.Text = eventName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String content = richTextBox1.Text;
            repository.postComment(cl, id_event, content, con);
            con.Close();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
