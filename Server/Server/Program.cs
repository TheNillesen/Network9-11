using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    class Program
    {
        private static int _port = 5555;
        private static bool _isRunning;

        private static TcpListener _server;

        public static BinaryFormatter biform = new BinaryFormatter();

        static void Main(string[] args)
        {
            XmlHandler.Write();
            Console.WriteLine("Server");
            Console.WriteLine("Waiting for connection");
            TcpServer(_port);
        }

        private static void TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();
            _isRunning = true;
            LoopClients();
        }

        private static void LoopClients()
        {
            while (_isRunning)
            {
                TcpClient newClient = _server.AcceptTcpClient();
                IPEndPoint endPoint = (IPEndPoint)newClient.Client.RemoteEndPoint;
                Console.WriteLine("A rat in the trap: " + endPoint.ToString());

                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);

            string sData = null;

            IPEndPoint endPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            IPEndPoint localEndpoint = (IPEndPoint)client.Client.LocalEndPoint;

            //First information from server
            ServerGlobals.playerList.Add(new PlayerStruct(0, 0, false, client));

            byte[] temp = File.ReadAllBytes("FloofDoc");
            client.GetStream().Write(temp, 0, temp.Length);
            client.GetStream().Flush();

            while (client.Connected)
            {
                try
                {
                    sData = sReader.ReadLine();
                }
                catch
                {                    
                    Console.WriteLine("Client onport " + endPoint.Port.ToString() + " has gone away.");
                    Thread.CurrentThread.Abort();
                }
                if (sData != string.Empty)
                {
                    Console.WriteLine(sData);
                }
                sWriter.Flush();
            }
        }
    }
}
