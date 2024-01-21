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
    public partial class KlientMenu : Form
    {
        BaseRepository repository;
        NpgsqlConnection con;
        DataTable dt;
        DataTable comments;
        List<String> cities;
        List<String> categories;
        Client client;
        String selectedMasterName;
        String selectedEventName;
        String selectedDate;
        String selectedCity;
        String selectedDescription;
        String selectedStreet;
        String selectedApartment;
        String selectedBuilding;
        Int32 selectedID;
        Boolean backBTNvisibility = false;
        Boolean browsingComments = false;
        public KlientMenu(String name, Int32 id, Boolean logged, Boolean isMastermind)
        {
            InitializeComponent();
            client = new Client();
            client.Username = name;
            client.Id = id;
            client.Logged = logged;
            client.IsMastermind = isMastermind;
            repository = new BaseRepository();
            var cs = @"User ID=szymon;Password=NHY3ooK9arUzQuIt;Host=frog01.mikr.us;Port=20960;Database=eventsdb";
            con = new NpgsqlConnection(cs);
            dt = new DataTable();
            DataColumn eventName = new DataColumn();
            eventName.DataType = System.Type.GetType("System.String");
            eventName.ColumnName = "Nazwa wydarzenia";
            DataColumn masterName = new DataColumn();
            masterName.DataType = System.Type.GetType("System.String");
            masterName.ColumnName = "Nazwa organizatora";
            DataColumn cityName = new DataColumn();
            cityName.DataType = System.Type.GetType("System.String");
            cityName.ColumnName = "Miasto";
            DataColumn streetName = new DataColumn();
            streetName.DataType = System.Type.GetType("System.String");
            streetName.ColumnName = "Ulica";
            DataColumn building = new DataColumn();
            building.DataType = System.Type.GetType("System.Int32");
            building.ColumnName = "Nr. budynku";
            DataColumn apartment = new DataColumn();
            apartment.DataType = System.Type.GetType("System.Int32");
            apartment.ColumnName = "Nr. lokalu";
            DataColumn date = new DataColumn();
            date.DataType = System.Type.GetType("System.DateTime");
            date.ColumnName = "Data";
            DataColumn description = new DataColumn();
            description.DataType = System.Type.GetType("System.String");
            description.ColumnName = "Opis";
            dt.Columns.Add(eventName);
            dt.Columns.Add(masterName);
            dt.Columns.Add(cityName);  
            dt.Columns.Add(streetName);
            dt.Columns.Add(apartment);
            dt.Columns.Add(building);
            dt.Columns.Add(date);
            dt.Columns.Add(description);

               


            comments = new DataTable();
            DataColumn uName = new DataColumn();
            uName.DataType = System.Type.GetType("System.String");
            uName.ColumnName = "Nazwa użytkownika";
            DataColumn uComment = new DataColumn();
            uComment.DataType = System.Type.GetType("System.String");
            uComment.ColumnName = "Komentarz";
            comments.Columns.Add(uName);
            comments.Columns.Add(uComment);
            con.Open();
            client.IsMastermind = repository.checkIfMaster(client.Id, con);
            con.Close();
            if (client.IsMastermind)
            {
                button7.Hide();
            }


            categories = new List<string>();
            cities = new List<string>();
            fillComboBoxes();
            dataGridView1.ReadOnly = true;
            label8.Text = "Zalogowano jako " + client.Username;
            //tableLayoutPanel1.ControlAdded += 
            showBTN();
            
        }
        private void showBTN()
        {
            if (backBTNvisibility == false)
            {
                bckBTN.Hide();
            }
            else
            {
                bckBTN.Show();
            }
        }
        private void FillDG()
        {
            dt.Clear();
            String eventName, masterMindName, cityName, categoryName;
            DateTime date, eDate;
            eventName = EventName.Text;
            masterMindName = MastermindName.Text;
            cityName = CityBox.Text;
            categoryName = CategoryBox.Text;
            date = dateBox.Value;
            eDate = endDate.Value;
            con.Open();
            dt = repository.FillDG(eventName, masterMindName, cityName, categoryName, date, eDate, con, dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[7].Width =
               dataGridView1.Width
               - dataGridView1.Columns[0].Width
               - dataGridView1.Columns[1].Width
               - dataGridView1.Columns[2].Width
               - dataGridView1.Columns[3].Width
               - dataGridView1.Columns[4].Width
               - dataGridView1.Columns[5].Width
               - dataGridView1.Columns[6].Width;
            con.Close();
        }
        private void fillComboBoxes()
        {
            con.Open();
            cities = repository.getCities(cities,con);
            con.Close();
            //
            con.Open();
            categories = repository.getCategories(categories,con);
            con.Close();
            CityBox.Items.Add("");
            CategoryBox.Items.Add("");
            for( int i = 0; i < cities.Count; i++)
            {
                CityBox.Items.Add(cities[i]);
            }
            for (int i = 0; i < categories.Count; i++)
            {
                CategoryBox.Items.Add(categories[i]);
            }
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillDG();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridView1.CurrentRow.Selected = true;
                    selectedEventName = dataGridView1.Rows[e.RowIndex].Cells["Nazwa wydarzenia"].Value.ToString();
                    selectedMasterName = dataGridView1.Rows[e.RowIndex].Cells["Nazwa organizatora"].Value.ToString();
                    selectedCity = dataGridView1.Rows[e.RowIndex].Cells["Miasto"].Value.ToString();
                    selectedStreet = dataGridView1.Rows[e.RowIndex].Cells["Ulica"].Value.ToString();
                    selectedDescription = dataGridView1.Rows[e.RowIndex].Cells["Opis"].Value.ToString();
                    selectedBuilding = dataGridView1.Rows[e.RowIndex].Cells["Nr. budynku"].Value.ToString();
                    selectedApartment = dataGridView1.Rows[e.RowIndex].Cells["Nr. lokalu"].Value.ToString();
                    selectedDate = dataGridView1.Rows[e.RowIndex].Cells["Data"].Value.ToString();
                    DateTime dateS = DateTime.Parse(selectedDate);
                    selectedDate = dateS.ToString("yyyy-MM-dd HH:mm:ss");


                }
            }
            
        }
        //Przeglądanie komentarzy
        private void button5_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            if (!browsingComments&&selectedEventName!=null)
            {
                con.Open();
                selectedID = repository.getEventId(selectedEventName, selectedMasterName, selectedDate, con);
                con.Close();
                comments.Clear();
                backBTNvisibility = true;
                showBTN();
                con.Open();
                comments = repository.loadComments(comments, selectedID, con);
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = comments;
                dataGridView1.Columns[1].Width =
                   dataGridView1.Width
                   - dataGridView1.Columns[0].Width;
                con.Close();
                browsingComments = true;
            }
            else
            {
                label9.Text = "Należy najpierw wybrać wydarzenie!";            }
            
        }

        private void bckBTN_Click(object sender, EventArgs e)
        {
            backBTNvisibility = false;
            browsingComments = false;
            showBTN();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[7].Width =
               dataGridView1.Width
               - dataGridView1.Columns[0].Width
               - dataGridView1.Columns[1].Width
               - dataGridView1.Columns[2].Width
               - dataGridView1.Columns[3].Width
               - dataGridView1.Columns[4].Width
               - dataGridView1.Columns[5].Width
               - dataGridView1.Columns[6].Width;
            comments.Clear();
        }

        private void postCommentBTN_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            if (selectedEventName != null)
            {
                con.Open();
                selectedID = repository.getEventId(selectedEventName, selectedMasterName, selectedDate, con);
                con.Close();
                PostComment pc = new PostComment(selectedID, client.Id, client.Logged, selectedEventName);
                Thread thread = new Thread(() => Application.Run(pc))
                {
                    IsBackground = false
                };
                thread.Start();
            }
            else
            {
                label9.Text = "Należy najpierw wybrać wydarzenie!";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(client.IsMastermind == false)
            {
                CreateMaster cm = new CreateMaster(client.Username, client.Id);
                Thread th = new Thread(() => Application.Run(cm))
                { IsBackground = false };
                th.Start();
                client.IsMastermind = true;
                button7.Hide();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            Int32 id_org = repository.getIdOrg(client.Id,con);
            con.Close();
            con.Open();
            Int32 addressID = repository.getOrgAdd(client.Id, con);
            con.Close();
            PostEvent pe = new PostEvent(id_org,addressID);
            Thread the = new Thread(() => Application.Run(pe))
            { IsBackground = false };
            the.Start();
        }
    }
}
