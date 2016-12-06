using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    delegate void UpdateServerInfoInvoker(string text);

    public partial class ServerForm : Form
    {
        ChatServer server;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            server = new ChatServer(this);
            ServerInfo.Items.Add("Server started");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.StopServer();
            ServerInfo.Items.Add("Server stopped");
        }

        public void UpdateServerInfo(string text)
        {
            SetText(text);
        }

        public void SetText(string text)
        {
            if (ServerInfo.InvokeRequired)
            {
                ServerInfo.Invoke(new UpdateServerInfoInvoker(UpdateServerInfo), text);
            }
            else
            {
                ServerInfo.Items.Add(text);
            }
        }
    }
}
