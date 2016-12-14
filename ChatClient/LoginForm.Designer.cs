namespace ChatClient
{
    partial class LoginForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ServerErrorLabel = new System.Windows.Forms.Label();
            this.ServerIPLogText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FailedLoginLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PasswordLoginText = new System.Windows.Forms.TextBox();
            this.UsernameLoginText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ServerIPAddressText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PasswordWarningLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.PasswordRegText = new System.Windows.Forms.TextBox();
            this.ConfirmPassRegText = new System.Windows.Forms.TextBox();
            this.UsernameRegText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(470, 305);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ServerErrorLabel);
            this.tabPage1.Controls.Add(this.ServerIPLogText);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.FailedLoginLabel);
            this.tabPage1.Controls.Add(this.LoginButton);
            this.tabPage1.Controls.Add(this.PasswordLoginText);
            this.tabPage1.Controls.Add(this.UsernameLoginText);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(462, 267);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ServerErrorLabel
            // 
            this.ServerErrorLabel.AutoSize = true;
            this.ServerErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ServerErrorLabel.Location = new System.Drawing.Point(8, 179);
            this.ServerErrorLabel.Name = "ServerErrorLabel";
            this.ServerErrorLabel.Size = new System.Drawing.Size(174, 25);
            this.ServerErrorLabel.TabIndex = 1;
            this.ServerErrorLabel.Text = "No active server!";
            this.ServerErrorLabel.Visible = false;
            // 
            // ServerIPLogText
            // 
            this.ServerIPLogText.Location = new System.Drawing.Point(218, 133);
            this.ServerIPLogText.Name = "ServerIPLogText";
            this.ServerIPLogText.Size = new System.Drawing.Size(202, 31);
            this.ServerIPLogText.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "IP Address of server";
            // 
            // FailedLoginLabel
            // 
            this.FailedLoginLabel.AutoSize = true;
            this.FailedLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FailedLoginLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.FailedLoginLabel.Location = new System.Drawing.Point(11, 11);
            this.FailedLoginLabel.Name = "FailedLoginLabel";
            this.FailedLoginLabel.Size = new System.Drawing.Size(405, 20);
            this.FailedLoginLabel.TabIndex = 5;
            this.FailedLoginLabel.Text = "The username and password combination do not match!";
            this.FailedLoginLabel.Visible = false;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(276, 211);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(180, 50);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordLoginText
            // 
            this.PasswordLoginText.Location = new System.Drawing.Point(119, 87);
            this.PasswordLoginText.Name = "PasswordLoginText";
            this.PasswordLoginText.Size = new System.Drawing.Size(301, 31);
            this.PasswordLoginText.TabIndex = 3;
            this.PasswordLoginText.UseSystemPasswordChar = true;
            // 
            // UsernameLoginText
            // 
            this.UsernameLoginText.Location = new System.Drawing.Point(119, 41);
            this.UsernameLoginText.Name = "UsernameLoginText";
            this.UsernameLoginText.Size = new System.Drawing.Size(301, 31);
            this.UsernameLoginText.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "username";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ServerIPAddressText);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.PasswordWarningLabel);
            this.tabPage2.Controls.Add(this.RegisterButton);
            this.tabPage2.Controls.Add(this.PasswordRegText);
            this.tabPage2.Controls.Add(this.ConfirmPassRegText);
            this.tabPage2.Controls.Add(this.UsernameRegText);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(462, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Register";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ServerIPAddressText
            // 
            this.ServerIPAddressText.Location = new System.Drawing.Point(218, 150);
            this.ServerIPAddressText.Name = "ServerIPAddressText";
            this.ServerIPAddressText.Size = new System.Drawing.Size(193, 31);
            this.ServerIPAddressText.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "IP Address of server";
            // 
            // PasswordWarningLabel
            // 
            this.PasswordWarningLabel.AutoSize = true;
            this.PasswordWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordWarningLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.PasswordWarningLabel.Location = new System.Drawing.Point(116, 132);
            this.PasswordWarningLabel.Name = "PasswordWarningLabel";
            this.PasswordWarningLabel.Size = new System.Drawing.Size(157, 16);
            this.PasswordWarningLabel.TabIndex = 7;
            this.PasswordWarningLabel.Text = "Passwords do not match!";
            this.PasswordWarningLabel.Visible = false;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(276, 211);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(180, 50);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // PasswordRegText
            // 
            this.PasswordRegText.Location = new System.Drawing.Point(119, 50);
            this.PasswordRegText.Name = "PasswordRegText";
            this.PasswordRegText.Size = new System.Drawing.Size(292, 31);
            this.PasswordRegText.TabIndex = 5;
            this.PasswordRegText.UseSystemPasswordChar = true;
            // 
            // ConfirmPassRegText
            // 
            this.ConfirmPassRegText.Location = new System.Drawing.Point(119, 98);
            this.ConfirmPassRegText.Name = "ConfirmPassRegText";
            this.ConfirmPassRegText.Size = new System.Drawing.Size(292, 31);
            this.ConfirmPassRegText.TabIndex = 4;
            this.ConfirmPassRegText.UseSystemPasswordChar = true;
            // 
            // UsernameRegText
            // 
            this.UsernameRegText.Location = new System.Drawing.Point(119, 7);
            this.UsernameRegText.Name = "UsernameRegText";
            this.UsernameRegText.Size = new System.Drawing.Size(292, 31);
            this.UsernameRegText.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 50);
            this.label5.TabIndex = 2;
            this.label5.Text = "confirm\r\npassword";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "username";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 329);
            this.Controls.Add(this.tabControl1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox PasswordLoginText;
        private System.Windows.Forms.TextBox UsernameLoginText;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox PasswordRegText;
        private System.Windows.Forms.TextBox ConfirmPassRegText;
        private System.Windows.Forms.TextBox UsernameRegText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FailedLoginLabel;
        private System.Windows.Forms.Label PasswordWarningLabel;
        private System.Windows.Forms.TextBox ServerIPLogText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ServerIPAddressText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ServerErrorLabel;

    }
}