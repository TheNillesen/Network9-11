using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;


namespace Server
{
    class Program
    {
        private static int _port = 5555;
        private static bool _isRunning;

        private static TcpListener _server;

        static void Main(string[] args)
        {
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
                sWriter.WriteLine("Welcome aboard");
                sWriter.Flush();
            }
        }
    }
}
