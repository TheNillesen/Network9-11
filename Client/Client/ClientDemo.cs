using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    class ClientDemo
    {
        private TcpClient _client;
        private StreamReader _sReader;
        private StreamWriter _sWriter;
        private bool _isConnected;

        public ClientDemo(string ipAdress, int portNum)
        {
            _client = new TcpClient();
            _client.Connect(ipAdress, portNum);
            HandleCommunication();
        }

        public void HandleCommunication()
        {
            _sReader = new StreamReader(_client.GetStream(), Encoding.ASCII);
            _sWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);

            _isConnected = true;
            string sData = null;
            string sDataIncoming = string.Empty;

            while (_isConnected)
            {
                Console.WriteLine("I got contact with the server.");
                sData = Console.ReadLine();
                _sWriter.WriteLine(sData);
                try
                {
                    _sWriter.Flush(); //Ensures that all data is sendt
                    sDataIncoming = _sReader.ReadLine();
                }
                catch
                {
                    Console.WriteLine("The server is gone.");
                    Console.ReadLine();
                    Thread.CurrentThread.Abort();
                }
                if (sDataIncoming != string.Empty)
                {
                    Console.WriteLine(sDataIncoming);
                }
            }
        }
    }
}
