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
    public partial class LoginForm : Form
    {
        ChatClient client;
        ClientForm clientForm;

        public LoginForm()
        {
            clientForm = new ClientForm(this);
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameLoginText.Text;
            string password = PasswordLoginText.Text;

            string serverIPAddress = ServerIPAddressText.Text;
            try
            {
                client = new ChatClient(username, password, serverIPAddress, clientForm, MessageTypes.LoginMessage);
                clientForm.Client = client;
            }
            catch (System.Net.Sockets.SocketException)
            {
                PasswordLoginText.Clear();
                ServerErrorLabel.Visible = true;
                return;
            }
            catch(Exception)
            {
                PasswordLoginText.Clear();
                FailedLoginLabel.Visible = true;
                return;
            }

            clientForm.Show();
            this.Hide();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = UsernameRegText.Text;
            string password = PasswordRegText.Text;
            string passwordConfirmation = ConfirmPassRegText.Text;

            if (!password.Equals(passwordConfirmation))
            {
                PasswordRegText.Clear();
                ConfirmPassRegText.Clear();
                PasswordWarningLabel.Visible = true;
            }
            else
            {
                PasswordWarningLabel.Visible = false;

                string serverIPAddress = ServerIPAddressText.Text;
                try
                {
                    client = new ChatClient(username, password, serverIPAddress, clientForm, MessageTypes.RegisterMessage);
                    clientForm.Client = client;
                }
                catch (Exception)
                {
                    PasswordRegText.Clear();
                    ConfirmPassRegText.Clear();
                    return;
                }

                clientForm.Show();
                this.Hide();
            }
        }
    }
}
