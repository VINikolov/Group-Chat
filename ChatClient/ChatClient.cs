using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    public class ChatClient
    {
        public string Name { get; set; }
        private TcpClient client;
        private Thread messageReceiver;
        private bool clientClose = false;

        public ChatClient(string username, string password, string serverIP, ClientForm form, MessageTypes messageType)
        {
            var ipAddress = IPAddress.Parse(serverIP);
            IPEndPoint endPoint = new IPEndPoint(ipAddress, 3333);
            client = new TcpClient();
            client.Connect(endPoint);

            string message = messageType.ToString() + " " + username + " " + password;
            string serverMessage = SendInitialMessageToServer(message);

            if (serverMessage.Equals(MessageTypes.LoginSuccessful.ToString()) || 
                serverMessage.Equals(MessageTypes.RegistrationSuccessful.ToString()))
            {
                Name = username;
                messageReceiver = new Thread(new ParameterizedThreadStart(ReceiveMessages));
                messageReceiver.Start(form);
                form.WriteMessage("Connected to server!");
                form.AddUser(username);
            }
            else
            {
                client = null;
                throw new Exception();
            }
        }

        private string SendInitialMessageToServer(string message)
        {
            NetworkStream clientDataStream = client.GetStream();
            byte[] buffer = new byte[4096];
            buffer = Encoding.ASCII.GetBytes(message);
            clientDataStream.Write(buffer, 0, message.Length);

            byte[] bytesRead = new byte[4096];
            NetworkStream clientStream = client.GetStream();
            int bytesCount = clientStream.Read(bytesRead, 0, 4096);
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetString(bytesRead, 0, bytesCount);
        }

        public void ReceiveMessages(object formObj)
        {
            ClientForm form = (ClientForm)formObj;
            try
            {
                NetworkStream clientDataStream = client.GetStream();
                byte[] buffer = new byte[4096];
                int bytesRead = 0;

                while (true)
                {
                    bytesRead = clientDataStream.Read(buffer, 0, 4096);

                    if (bytesRead == 0)
                    {
                        if (clientClose == false)
                        {
                            form.WriteMessage("Server Disconnected!");
                        }
                        break;
                    }

                    ASCIIEncoding encoding = new ASCIIEncoding();
                    string message = encoding.GetString(buffer, 0, bytesRead);

                    if (message.StartsWith(MessageTypes.UpdateMessage.ToString()))
                    {
                        string text = message.Substring(message.IndexOf(' ') + 1);
                        if (text.IndexOf(' ') == -1)
                        {
                            form.AddUser(text);
                        }
                        else
                        {
                            string[] users = text.Split(' ');
                            for (int i = 0; i < users.Length - 1; i++)
                            {
                                form.AddUser(users[i]);
                            }
                        }
                    }
                    else if (message.StartsWith(MessageTypes.UserDisconnectedNotification.ToString()))
                    {
                        string name = message.Substring(message.IndexOf(' ') + 1);
                        name = name.TrimEnd(' ');
                        form.RemoveUser(name);
                    }
                    else
                    {
                        form.WriteMessage(message);
                    }
                }
            }
            catch (Exception)
            {
                if (clientClose == false)
                {
                    form.WriteMessage("Server Disconnected!");
                }
                return;
            }
        }

        public void SendMessage(string message)
        {
            if (client == null)
            {
                return;
            }
            byte[] convertedMessage = Encoding.ASCII.GetBytes(message);
            NetworkStream clientDataStream = client.GetStream();
            clientDataStream.Write(convertedMessage, 0, convertedMessage.Length);
        }

        public void Close()
        {
            clientClose = true;
            client.Close();
        }
    }
}
