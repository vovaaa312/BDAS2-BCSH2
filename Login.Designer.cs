namespace SemestralniPraceB_Makarneko
{
    partial class Login
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
            this.PasswordLable = new System.Windows.Forms.Label();
            this.EmailTextBoox = new System.Windows.Forms.TextBox();
            this.PasswordTextBoox = new System.Windows.Forms.TextBox();
            this.GuestButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email:";
            // 
            // PasswordLable
            // 
            this.PasswordLable.AutoSize = true;
            this.PasswordLable.Location = new System.Drawing.Point(194, 180);
            this.PasswordLable.Name = "PasswordLable";
            this.PasswordLable.Size = new System.Drawing.Size(56, 13);
            this.PasswordLable.TabIndex = 1;
            this.PasswordLable.Text = "Password:";
            // 
            // EmailTextBoox
            // 
            this.EmailTextBoox.Location = new System.Drawing.Point(194, 147);
            this.EmailTextBoox.Name = "EmailTextBoox";
            this.EmailTextBoox.Size = new System.Drawing.Size(100, 20);
            this.EmailTextBoox.TabIndex = 2;
            this.EmailTextBoox.TextChanged += new System.EventHandler(this.EmailTextBoox_TextChanged);
            // 
            // PasswordTextBoox
            // 
            this.PasswordTextBoox.Location = new System.Drawing.Point(194, 209);
            this.PasswordTextBoox.Name = "PasswordTextBoox";
            this.PasswordTextBoox.PasswordChar = '*';
            this.PasswordTextBoox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextBoox.TabIndex = 3;
            this.PasswordTextBoox.TextChanged += new System.EventHandler(this.PasswordTextBoox_TextChanged);
            // 
            // GuestButton
            // 
            this.GuestButton.Location = new System.Drawing.Point(385, 310);
            this.GuestButton.Name = "GuestButton";
            this.GuestButton.Size = new System.Drawing.Size(75, 23);
            this.GuestButton.TabIndex = 4;
            this.GuestButton.Text = "Guest";
            this.GuestButton.UseVisualStyleBackColor = true;
            this.GuestButton.Click += new System.EventHandler(this.GuestButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(206, 310);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Location = new System.Drawing.Point(40, 309);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(75, 23);
            this.RegistrationButton.TabIndex = 6;
            this.RegistrationButton.Text = "Registration";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 450);
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.GuestButton);
            this.Controls.Add(this.PasswordTextBoox);
            this.Controls.Add(this.EmailTextBoox);
            this.Controls.Add(this.PasswordLable);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PasswordLable;
        private System.Windows.Forms.TextBox EmailTextBoox;
        private System.Windows.Forms.TextBox PasswordTextBoox;
        private System.Windows.Forms.Button GuestButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegistrationButton;
    }
}