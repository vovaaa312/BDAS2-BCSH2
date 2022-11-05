namespace SemestralniPraceB_Makarneko
{
    partial class Registr
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
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.ConPasswordTextBox = new System.Windows.Forms.TextBox();
            this.EmailLable = new System.Windows.Forms.Label();
            this.PasswordLable = new System.Windows.Forms.Label();
            this.ConfirmPasswordLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Location = new System.Drawing.Point(202, 311);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(97, 23);
            this.RegistrationButton.TabIndex = 0;
            this.RegistrationButton.Text = "Regisetration";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(199, 204);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(199, 158);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(100, 20);
            this.EmailTextBox.TabIndex = 2;
            // 
            // ConPasswordTextBox
            // 
            this.ConPasswordTextBox.Location = new System.Drawing.Point(199, 248);
            this.ConPasswordTextBox.Name = "ConPasswordTextBox";
            this.ConPasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.ConPasswordTextBox.TabIndex = 3;
            // 
            // EmailLable
            // 
            this.EmailLable.AutoSize = true;
            this.EmailLable.Location = new System.Drawing.Point(196, 142);
            this.EmailLable.Name = "EmailLable";
            this.EmailLable.Size = new System.Drawing.Size(35, 13);
            this.EmailLable.TabIndex = 4;
            this.EmailLable.Text = "Email:";
            // 
            // PasswordLable
            // 
            this.PasswordLable.AutoSize = true;
            this.PasswordLable.Location = new System.Drawing.Point(196, 188);
            this.PasswordLable.Name = "PasswordLable";
            this.PasswordLable.Size = new System.Drawing.Size(56, 13);
            this.PasswordLable.TabIndex = 5;
            this.PasswordLable.Text = "Password:";
            this.PasswordLable.Click += new System.EventHandler(this.PasswordLable_Click);
            // 
            // ConfirmPasswordLable
            // 
            this.ConfirmPasswordLable.AutoSize = true;
            this.ConfirmPasswordLable.Location = new System.Drawing.Point(199, 231);
            this.ConfirmPasswordLable.Name = "ConfirmPasswordLable";
            this.ConfirmPasswordLable.Size = new System.Drawing.Size(93, 13);
            this.ConfirmPasswordLable.TabIndex = 6;
            this.ConfirmPasswordLable.Text = "Confirm password:";
            // 
            // Registr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 450);
            this.Controls.Add(this.ConfirmPasswordLable);
            this.Controls.Add(this.PasswordLable);
            this.Controls.Add(this.EmailLable);
            this.Controls.Add(this.ConPasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.RegistrationButton);
            this.Name = "Registr";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox ConPasswordTextBox;
        private System.Windows.Forms.Label EmailLable;
        private System.Windows.Forms.Label PasswordLable;
        private System.Windows.Forms.Label ConfirmPasswordLable;
    }
}