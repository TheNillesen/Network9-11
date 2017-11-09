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
    }
}
