using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace ChatServer
{
    public class ChatServer
    {
        private TcpListener server;
        private Thread listenerThread;
        private IDictionary<string, TcpClient> connectedUsers;

        public ChatServer(ServerForm form)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(ipAddress, 3333);
            listenerThread = new Thread(new ParameterizedThreadStart(ListenForClients));
            listenerThread.Start(form);
            connectedUsers = new Dictionary<string, TcpClient>();
        }

        private void ListenForClients(object formObj)
        {
            ServerForm form = (ServerForm)formObj;
            server.Start();

            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();

                    Thread clientThread = new Thread(() => ClientCommunicationHandler(client, form));
                    clientThread.Start();
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        private void ClientCommunicationHandler(object client, object formObj)
        {
            ServerForm form = (ServerForm)formObj;
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientDataStream = tcpClient.GetStream();
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            string clientName = "";

            while (true)
            {
                try
                {
                    bytesRead = clientDataStream.Read(buffer, 0, 4096);
                }
                catch (System.IO.IOException)
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                ASCIIEncoding encoding = new ASCIIEncoding();
                string message = encoding.GetString(buffer, 0, bytesRead);

                if (IsExitMessage(message))
                {
                    HandleUserDisconnect(clientName, form);
                    break;
                }
                else if (message.StartsWith(MessageTypes.LoginMessage.ToString()))
                {
                    string data = message.Substring(message.IndexOf(' ') + 1);
                    clientName = data.Substring(0, data.IndexOf(' '));
                    string password = data.Substring(clientName.Length + 1);

                    if (VerifyUserCredentials(clientName, password))
                    {
                        string text = clientName + " connected.";
                        form.UpdateServerInfo(text);

                        string notificationMessage = MessageTypes.LoginSuccessful.ToString();
                        SendMessage(notificationMessage, tcpClient);

                        SendInitialData(tcpClient, clientName);
                        connectedUsers.Add(clientName, tcpClient);
                    }
                    else
                    {
                        string notificationMessage = MessageTypes.LoginFailed.ToString();
                        SendMessage(notificationMessage, tcpClient);
                    }
                }
                else if (message.StartsWith(MessageTypes.RegisterMessage.ToString()))
                {
                    string data = message.Substring(message.IndexOf(' ') + 1);
                    clientName = data.Substring(0, data.IndexOf(' '));
                    string password = data.Substring(clientName.Length + 1);

                    RegisterUser(clientName, password);

                    string notificationMessage = MessageTypes.RegistrationSuccessful.ToString();
                    SendMessage(notificationMessage, tcpClient);

                    SendInitialData(tcpClient, clientName);
                    connectedUsers.Add(clientName, tcpClient);
                }
                else
                {
                    SendMessageToAllUsers(buffer, bytesRead);
                }
            }
        }

        private void SendMessage(string notificationMessage, TcpClient tcpClient)
        {
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] notification = Encoding.ASCII.GetBytes(notificationMessage);
            clientStream.Write(notification, 0, notificationMessage.Length);
        }

        private void SendInitialData(TcpClient tcpClient, string clientName)
        {
            string text = clientName + " connected.";
            byte[] connectMessage = Encoding.ASCII.GetBytes(text);
            int length = text.Length;

            SendMessageToAllUsers(connectMessage, length);

            StringBuilder connectedUsersSb = new StringBuilder();
            foreach (var item in connectedUsers)
            {
                connectedUsersSb.Append(item.Key);
                connectedUsersSb.Append(" ");
            }


            if (connectedUsersSb.Length > 0)
            {
                string connectedUsersStr = MessageTypes.UpdateMessage.ToString() + " " + connectedUsersSb.ToString();
                byte[] updateUsersMessage = Encoding.ASCII.GetBytes(connectedUsersStr);
                NetworkStream dataStream = tcpClient.GetStream();
                dataStream.Write(updateUsersMessage, 0, connectedUsersStr.Length);

                string updateMessage = MessageTypes.UpdateMessage.ToString() + " " + clientName;
                byte[] updateMessageBytes = Encoding.ASCII.GetBytes(updateMessage);
                SendMessageToAllUsers(updateMessageBytes, updateMessage.Length);
            }
        }

        private void HandleUserDisconnect(string clientName, ServerForm form)
        {
            string text = clientName + " has disconnected.";
            form.UpdateServerInfo(text);
            connectedUsers.Remove(clientName);

            byte[] disconnectMessage = Encoding.ASCII.GetBytes(text);
            int length = text.Length;

            string notificationMessage = MessageTypes.UserDisconnectedNotification + " " + clientName;
            byte[] notification = Encoding.ASCII.GetBytes(notificationMessage);

            SendMessageToAllUsers(disconnectMessage, length);
            SendMessageToAllUsers(notification, notificationMessage.Length);
        }

        private void SendMessageToAllUsers(byte[] message, int bytesRead)
        {
            foreach (var item in connectedUsers)
            {
                NetworkStream dataStream = item.Value.GetStream();
                dataStream.Write(message, 0, bytesRead);
            }
        }

        private bool IsExitMessage(string message)
        {
            return message.StartsWith(MessageTypes.ExitMessage.ToString());
        }

        private string GetHashedPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        private void RegisterUser(string username, string password)
        {
            string hashedPass = GetHashedPassword(password);
            username = username.ToLower();

            string xmlFilePath = "Accounts.xml";
            XDocument accountsDoc = XDocument.Load(xmlFilePath);

            XElement users = accountsDoc.Element("Users");
            users.Add(new XElement("User", 
                new XElement("Username", username),
                new XElement("Password", hashedPass)));

            accountsDoc.Save(xmlFilePath);
        }

        private bool VerifyUserCredentials(string username, string password)
        {
            username = username.ToLower();

            XDocument accountsDoc = XDocument.Load("Accounts.xml");
            var savedPasswordHash = accountsDoc.Element("Users").Descendants("User").
                Where(x => x.Value.Contains(username)).Descendants("Password").Select(x => x.Value);

            if (savedPasswordHash.Count() == 0)
            {
                return false;
            }
            else
            {
                string hashedPass = String.Join("", savedPasswordHash.ToArray());
                return PasswordsMatch(password, hashedPass);
            }
        }

        private bool PasswordsMatch(string password, string savedPasswordHash)
        {
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }

        public void StopServer()
        {
            server.Stop();
            foreach (var item in connectedUsers)
            {
                item.Value.Close();
            }
            connectedUsers.Clear();
        }
    }
}
