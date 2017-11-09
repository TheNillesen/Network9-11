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
    [Serializable]
    struct PlayerStruct
    {
        public int xPos;
        public int yPos;
        public bool isCatcher;
        public TcpClient tcpClient;

        public PlayerStruct(int xPos, int yPos, bool isCatcher, TcpClient tcpClient)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.isCatcher = isCatcher;
            this.tcpClient = tcpClient;
        }
    }
}
