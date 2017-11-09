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
    static class ServerGlobals
    {
        static public int xDimension;
        static public int yDimension;
        static public int time;
        static public char[,] map;
        static public List<PlayerStruct> playerList;

        static ServerGlobals()
        {
            Console.Write("Map width: ");
            xDimension = int.Parse(Console.ReadLine());
            Console.Write("Map height: ");
            yDimension = int.Parse(Console.ReadLine());
            Console.Write("Turn time: ");
            time = int.Parse(Console.ReadLine());
            map = new char[xDimension, yDimension];
            XmlHandler.WriteMap();
            playerList = new List<PlayerStruct>();
        }

    }
}
