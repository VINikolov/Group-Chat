using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    delegate void UpdateStatusInvoker(string text);
    delegate void UpdateUsersInvoker(string text);

    public partial class ClientForm : Form
    {
        public ChatClient Client { get; set; }
        private LoginForm loginForm;

        public ClientForm(LoginForm loginForm)
        {
            this.loginForm = loginForm as LoginForm;
            InitializeComponent();
        }

        public void WriteMessage(string message)
        {
            SetText(message);
        }

        public void SetText(string message)
        {
            if (MessageBox.InvokeRequired)
            {
                MessageBox.Invoke(new UpdateStatusInvoker(WriteMessage), message);
            }
            else
            {
                MessageBox.Items.Add(message);
            }
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            string message = Client.Name + " > " + MessageTextBox.Text;
            MessageTextBox.Clear();
            Client.SendMessage(message);
            message = "";
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }     

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            MessageTextBox.Clear();
            MessageBox.Items.Add("Disconnected from server!");
            string message = MessageTypes.ExitMessage.ToString();
            Client.SendMessage(message);
            ConnectedUsers.Items.Clear();
            Client.Close();
        }

        public void AddUser(string clientName)
        {
            SetUser(clientName);
        }

        public void SetUser(string user)
        {
            if (ConnectedUsers.InvokeRequired)
            {
                ConnectedUsers.Invoke(new UpdateUsersInvoker(AddUser), user);
            }
            else
            {
                ConnectedUsers.Items.Add(user);
            }
        }

        public void RemoveUser(string name)
        {
            ConnectedUsers.Items.Remove(name);
        }

        private void ClientForm_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
