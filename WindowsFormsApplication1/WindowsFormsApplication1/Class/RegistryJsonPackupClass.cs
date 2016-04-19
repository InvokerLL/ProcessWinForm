using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Tools;

namespace WindowsFormsApplication1.Class
{
    class RegistryJsonPackupClass
    {
        public void SendRegistryMessage(string mac,string name,string ip, Socket clientSocket)
        {
            //注册信息发送
            sendedFirstParamsClass s1Params = new sendedFirstParamsClass();//请求JSON的第一段
            s1Params.command = 769;
            s1Params.crc32 = 0;
            s1Params.devId = 566;
            s1Params.sn = 0;

            sendedSecondParamsClass s2Params = new sendedSecondParamsClass();//请求JSON的第二段
            s2Params.MacAddr = mac;
            s2Params.DevName = name;
            s2Params.IpAddr = ip;
            s2Params.devId = 0;

            string json1 = JsonParseTool.ConvertObjToJson(s1Params);
            string json2 = JsonParseTool.ConvertObjToJson(s2Params);
            clientSocket.Send(Encoding.ASCII.GetBytes(json1 + json2));
        }
    }
}
