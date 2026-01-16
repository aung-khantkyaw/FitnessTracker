namespace Fitness_Tracker
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            linkToRegister = new LinkLabel();
            linkToRegistration = new LinkLabel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnLogin = new Button();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // linkToRegister
            // 
            linkToRegister.Location = new Point(0, 0);
            linkToRegister.Name = "linkToRegister";
            linkToRegister.Size = new Size(100, 23);
            linkToRegister.TabIndex = 0;
            // 
            // linkToRegistration
            // 
            linkToRegistration.AutoSize = true;
            linkToRegistration.BackColor = Color.Transparent;
            linkToRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkToRegistration.Location = new Point(524, 425);
            linkToRegistration.Name = "linkToRegistration";
            linkToRegistration.Size = new Size(91, 17);
            linkToRegistration.TabIndex = 13;
            linkToRegistration.TabStop = true;
            linkToRegistration.Text = "Register Here";
            linkToRegistration.LinkClicked += linkToRegistration_LinkClicked_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(367, 425);
            label3.Name = "label3";
            label3.Size = new Size(156, 17);
            label3.TabIndex = 12;
            label3.Text = "Don't have an account ?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(384, 309);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 11;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(384, 249);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 10;
            label1.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.Location = new Point(384, 375);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(214, 30);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(384, 333);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(214, 23);
            tbPassword.TabIndex = 8;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(384, 273);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(214, 23);
            tbUsername.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(356, 150);
            label4.Name = "label4";
            label4.Size = new Size(292, 40);
            label4.TabIndex = 14;
            label4.Text = "Fitness Tracker ";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(label4);
            Controls.Add(linkToRegistration);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fitness Tracker";
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel linkToRegister;
        private LinkLabel linkToRegistration;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnLogin;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private Label label4;
    }
}
