namespace ChatClient
{
    partial class ClientForm
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
            this.MessageBox = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.ConnectedUsers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MessageBox
            // 
            this.MessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageBox.FormattingEnabled = true;
            this.MessageBox.ItemHeight = 16;
            this.MessageBox.Location = new System.Drawing.Point(16, 32);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(509, 340);
            this.MessageBox.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(16, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 58);
            this.button2.TabIndex = 4;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(120, 379);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(639, 58);
            this.MessageTextBox.TabIndex = 5;
            // 
            // ConnectedUsers
            // 
            this.ConnectedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConnectedUsers.FormattingEnabled = true;
            this.ConnectedUsers.ItemHeight = 16;
            this.ConnectedUsers.Location = new System.Drawing.Point(531, 32);
            this.ConnectedUsers.Name = "ConnectedUsers";
            this.ConnectedUsers.Size = new System.Drawing.Size(227, 292);
            this.ConnectedUsers.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(528, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Connected users";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DisconnectButton.Location = new System.Drawing.Point(532, 330);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(227, 43);
            this.DisconnectButton.TabIndex = 9;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Chat";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 449);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConnectedUsers);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.MessageBox);
            this.Name = "ClientForm";
            this.Text = "Chat Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_Closing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox MessageBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.ListBox ConnectedUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Label label3;
    }
}

