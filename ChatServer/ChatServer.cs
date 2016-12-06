using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ChatServer
{
    public class ChatServer
    {
        private TcpListener server;
        private Thread listenerThread;
        private IDictionary<string, TcpClient> connectedUsers;

        public ChatServer(ServerForm form)
        {
            server = new TcpListener(IPAddress.Any, 3333);
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

                if (IsInitialMessage(message))
                {
                    clientName = message.Substring(message.IndexOf(' ') + 1);
                    string text = clientName + " connected.";
                    form.UpdateServerInfo(text);

                    SendInitialData(tcpClient, clientName);
  
                    connectedUsers.Add(clientName, tcpClient);
                }
                else if (IsExitMessage(message))
                {
                    HandleUserDisconnect(clientName, form);
                    break;
                }
                else
                {
                    SendMessageToAllUsers(buffer, bytesRead);
                }
            }
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

        private bool IsInitialMessage(string message)
        {
            return message.StartsWith(MessageTypes.InitialMessage.ToString());
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
