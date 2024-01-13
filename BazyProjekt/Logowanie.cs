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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyProjekt
{
    public partial class Logowanie : Form
    {
        Client client;
        BaseRepository repository;
        String name;
        String password;
        Boolean regResult = false;
        NpgsqlConnection con;
        public Logowanie()
        {
            InitializeComponent();
            client = new Client();
            repository = new BaseRepository();
            var cs = @"User ID=szymon;Password=NHY3ooK9arUzQuIt;Host=frog01.mikr.us;Port=20960;Database=eventsdb";
            con = new NpgsqlConnection(cs);
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            msgLbl.Text = "";
            //repository.establishCon(con);
            name = usernameField.Text;
            password = passField.Text;
            if (!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(password))
            {
                client = repository.login(name, password, con);
                
            }
            if (client.Logged == false)
            {
                msgLbl.Text = "Błędna nazwa lub hasło";
            }
            else
            {
                client.Id = repository.getUserId(name,con);
                client.Username = name;

            }
            client.Password = password;
            
            repository.logOut(name, client.Password, con);
          
            con.Close();
            if(client.Logged == true)
            {
                KlientMenu kMenu = new KlientMenu(client.Username,client.Id,true);
                //kMenu.Show(); 
                //Application.Run(new KlientMenu(client.Username,client.Id));
                Thread thread = new Thread(() => Application.Run(kMenu))
                {
                    IsBackground = false
                };
                thread.Start();
                this.Dispose();
               
            }
        }


        private void admnBtn_Click(object sender, EventArgs e)
        {

        }

        private void anonymousBtn_Click(object sender, EventArgs e)
        {

        }

        private void rgrBtn_Click(object sender, EventArgs e)
        {
            msgLbl.Text = "";
            con.Open();
            //repository.establishCon(con);
            name = usernameField.Text;
            password = passField.Text;
            if (!String.IsNullOrEmpty(name) || !String.IsNullOrEmpty(password))
            {
                regResult = repository.reg(name, password, con);
            }
            else
            {
                msgLbl.Text = "Błędna nazwa lub hasło";
            }
            if (!regResult)
            {
                if(msgLbl.Text!= "Błędna nazwa lub hasło")
                msgLbl.Text = "Nazwa jest zajęta";
            }
            else
            {
                msgLbl.Text = "Zarejestrowano poprawnie";
            }
           
            //repository.logOut(client.Username, client.Password, con);
           
            con.Close();
        }
    }
}
