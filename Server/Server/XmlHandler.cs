using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Server
{
    static class XmlHandler
    {
        static public void Write()
        {
            XmlDocument xDoc = new XmlDocument();

            var head = xDoc.AppendChild(xDoc.CreateElement("Players"));
            for(int i = 0; i < ServerGlobals.playerList.Count; i++)
            {
                XmlElement ele = xDoc.CreateElement("Floof");
                var xpos = ele.AppendChild(xDoc.CreateElement("PositionX"));
                xpos.InnerText = ServerGlobals.playerList[i].xPos.ToString();
                var ypos = ele.AppendChild(xDoc.CreateElement("PositionY"));
                ypos.InnerText = ServerGlobals.playerList[i].yPos.ToString();
                var catcher = ele.AppendChild(xDoc.CreateElement("IsCatcher"));
                catcher.InnerText = ServerGlobals.playerList[i].isCatcher.ToString();
                var ep = ele.AppendChild(xDoc.CreateElement("EndPoint"));
                ep.InnerText = ServerGlobals.playerList[i].tcpClient.Client.RemoteEndPoint.ToString();
            }
            xDoc.Save("FloofDoc");
        }

        static public void WriteMap()
        {
            XmlDocument xDoc = new XmlDocument();

            var head = xDoc.AppendChild(xDoc.CreateElement("Map"));

            XmlElement ele = xDoc.CreateElement("Fluuf");
            var xD = ele.AppendChild(xDoc.CreateElement("xDimension"));
            xD.InnerText = ServerGlobals.xDimension.ToString();
            var yD = ele.AppendChild(xDoc.CreateElement("yDimension"));
            yD.InnerText = ServerGlobals.yDimension.ToString();

            xDoc.Save("MapInfo");
        }
    }
}
