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
    class Program
    {
        static void Main(string[] args)
        {
            ClientDemo client = new ClientDemo("127.0.0.1", 5555);
        }
    }
}
