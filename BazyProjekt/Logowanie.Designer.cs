namespace BazyProjekt
{
    partial class Logowanie
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
            this.usernameField = new System.Windows.Forms.TextBox();
            this.passwdField = new System.Windows.Forms.TextBox();
            this.userBtn = new System.Windows.Forms.Button();
            this.anonymousBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passField = new System.Windows.Forms.TextBox();
            this.rgrBtn = new System.Windows.Forms.Button();
            this.msgLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameField
            // 
            this.usernameField.Location = new System.Drawing.Point(351, 116);
            this.usernameField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usernameField.Name = "usernameField";
            this.usernameField.Size = new System.Drawing.Size(415, 22);
            this.usernameField.TabIndex = 0;
            this.usernameField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwdField
            // 
            this.passwdField.Location = new System.Drawing.Point(0, 0);
            this.passwdField.Name = "passwdField";
            this.passwdField.Size = new System.Drawing.Size(100, 22);
            this.passwdField.TabIndex = 0;
            // 
            // userBtn
            // 
            this.userBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.userBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userBtn.Location = new System.Drawing.Point(351, 217);
            this.userBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userBtn.Name = "userBtn";
            this.userBtn.Size = new System.Drawing.Size(223, 47);
            this.userBtn.TabIndex = 2;
            this.userBtn.Text = "Zaloguj";
            this.userBtn.UseVisualStyleBackColor = false;
            this.userBtn.Click += new System.EventHandler(this.userBtn_Click);
            // 
            // anonymousBtn
            // 
            this.anonymousBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.anonymousBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.anonymousBtn.Location = new System.Drawing.Point(351, 430);
            this.anonymousBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.anonymousBtn.Name = "anonymousBtn";
            this.anonymousBtn.Size = new System.Drawing.Size(223, 47);
            this.anonymousBtn.TabIndex = 5;
            this.anonymousBtn.Text = "Anonimowy dostęp";
            this.anonymousBtn.UseVisualStyleBackColor = false;
            this.anonymousBtn.Click += new System.EventHandler(this.anonymousBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zaloguj się do aplikacji";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nazwa ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hasło";
            // 
            // passField
            // 
            this.passField.Location = new System.Drawing.Point(351, 185);
            this.passField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passField.Name = "passField";
            this.passField.Size = new System.Drawing.Size(411, 22);
            this.passField.TabIndex = 10;
            // 
            // rgrBtn
            // 
            this.rgrBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.rgrBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rgrBtn.Location = new System.Drawing.Point(351, 330);
            this.rgrBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rgrBtn.Name = "rgrBtn";
            this.rgrBtn.Size = new System.Drawing.Size(223, 47);
            this.rgrBtn.TabIndex = 11;
            this.rgrBtn.Text = "Rejestracja";
            this.rgrBtn.UseVisualStyleBackColor = false;
            this.rgrBtn.Click += new System.EventHandler(this.rgrBtn_Click);
            // 
            // msgLbl
            // 
            this.msgLbl.AutoSize = true;
            this.msgLbl.Location = new System.Drawing.Point(351, 65);
            this.msgLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(0, 16);
            this.msgLbl.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 299);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Zarejestruj:";
            // 
            // Logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msgLbl);
            this.Controls.Add(this.rgrBtn);
            this.Controls.Add(this.passField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anonymousBtn);
            this.Controls.Add(this.userBtn);
            this.Controls.Add(this.usernameField);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Logowanie";
            this.Text = "Logowanie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameField;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.Button userBtn;
        private System.Windows.Forms.Button anonymousBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwdField;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.Button rgrBtn;
        private System.Windows.Forms.Label msgLbl;
        private System.Windows.Forms.Label label1;
    }
}