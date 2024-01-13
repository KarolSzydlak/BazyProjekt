namespace BazyProjekt
{
    partial class KlientMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EventName = new System.Windows.Forms.TextBox();
            this.MastermindName = new System.Windows.Forms.TextBox();
            this.CityBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.disComm = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bckBTN = new System.Windows.Forms.Button();
            this.postCommentBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa wydarzenia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nazwa organizatora";
            // 
            // EventName
            // 
            this.EventName.Location = new System.Drawing.Point(113, 25);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(308, 20);
            this.EventName.TabIndex = 3;
            // 
            // MastermindName
            // 
            this.MastermindName.Location = new System.Drawing.Point(451, 25);
            this.MastermindName.Name = "MastermindName";
            this.MastermindName.Size = new System.Drawing.Size(308, 20);
            this.MastermindName.TabIndex = 4;
            // 
            // CityBox
            // 
            this.CityBox.FormattingEnabled = true;
            this.CityBox.Location = new System.Drawing.Point(786, 25);
            this.CityBox.Name = "CityBox";
            this.CityBox.Size = new System.Drawing.Size(126, 21);
            this.CityBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(783, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Miasto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(934, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kategoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Od";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // CategoryBox
            // 
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Location = new System.Drawing.Point(937, 24);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(140, 21);
            this.CategoryBox.TabIndex = 9;
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(113, 71);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(212, 20);
            this.dateBox.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(589, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "Szukaj";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(3, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 34);
            this.button2.TabIndex = 12;
            this.button2.Text = "Konto";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(3, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 34);
            this.button3.TabIndex = 13;
            this.button3.Text = "Statystyki";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(3, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 34);
            this.button4.TabIndex = 14;
            this.button4.Text = "Zapisane";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // disComm
            // 
            this.disComm.BackColor = System.Drawing.SystemColors.HotTrack;
            this.disComm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.disComm.Location = new System.Drawing.Point(3, 252);
            this.disComm.Name = "disComm";
            this.disComm.Size = new System.Drawing.Size(101, 34);
            this.disComm.TabIndex = 15;
            this.disComm.Text = "Przeglądać komentarze";
            this.disComm.UseVisualStyleBackColor = false;
            this.disComm.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Location = new System.Drawing.Point(3, 139);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 34);
            this.button6.TabIndex = 16;
            this.button6.Text = "Wyloguj";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.Location = new System.Drawing.Point(3, 179);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(101, 34);
            this.button7.TabIndex = 0;
            this.button7.Text = "Zostań organizatorem";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(349, 71);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(212, 20);
            this.endDate.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Do";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Po wybraniu wydarzenia z tabeli możesz:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1296, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "label8";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1096, 417);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(245, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1099, 420);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bckBTN
            // 
            this.bckBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bckBTN.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.bckBTN.Location = new System.Drawing.Point(113, 139);
            this.bckBTN.Name = "bckBTN";
            this.bckBTN.Size = new System.Drawing.Size(101, 34);
            this.bckBTN.TabIndex = 19;
            this.bckBTN.Text = "Powrót do wydarzeń";
            this.bckBTN.UseVisualStyleBackColor = false;
            this.bckBTN.Click += new System.EventHandler(this.bckBTN_Click);
            // 
            // postCommentBTN
            // 
            this.postCommentBTN.BackColor = System.Drawing.SystemColors.HotTrack;
            this.postCommentBTN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.postCommentBTN.Location = new System.Drawing.Point(113, 252);
            this.postCommentBTN.Name = "postCommentBTN";
            this.postCommentBTN.Size = new System.Drawing.Size(101, 34);
            this.postCommentBTN.TabIndex = 21;
            this.postCommentBTN.Text = "Zamieścić komentarz";
            this.postCommentBTN.UseVisualStyleBackColor = false;
            this.postCommentBTN.Click += new System.EventHandler(this.postCommentBTN_Click);
            // 
            // KlientMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1343, 545);
            this.Controls.Add(this.postCommentBTN);
            this.Controls.Add(this.bckBTN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.disComm);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.CategoryBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CityBox);
            this.Controls.Add(this.MastermindName);
            this.Controls.Add(this.EventName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "KlientMenu";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EventName;
        private System.Windows.Forms.TextBox MastermindName;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button disComm;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox CityBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CategoryBox;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bckBTN;
        private System.Windows.Forms.Button postCommentBTN;
    }
}