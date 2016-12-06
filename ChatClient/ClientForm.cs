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
        ChatClient client;

        public ClientForm()
        {
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
            string message = client.Name + " > " + MessageTextBox.Text;
            MessageTextBox.Clear();
            client.SendMessage(message);
            message = "";
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string clientName = ClientName.Text;
            if (clientName.Equals(String.Empty))
            {
                NameWarningLabel.Visible = true;
            }
            else
            {
                NameWarningLabel.Visible = false;
                client = new ChatClient(clientName, this);
                string initialMessage = MessageTypes.InitialMessage.ToString() + " " + clientName;
                client.SendMessage(initialMessage);
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            MessageTextBox.Clear();
            MessageBox.Items.Add("Disconnected from server!");
            string message = MessageTypes.ExitMessage.ToString();
            client.SendMessage(message);
            ConnectedUsers.Items.Clear();
            client.Close();
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
    }
}
