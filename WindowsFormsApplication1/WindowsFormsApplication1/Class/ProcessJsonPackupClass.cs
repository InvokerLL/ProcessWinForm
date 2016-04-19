using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Tools;

namespace WindowsFormsApplication1.Class
{
    class ProcessJsonPackupClass
    {
        public void SendProcessMessage(string content, Socket clientSocket)
        {
            //注册信息发送
            sendedFirstParamsClass s1Params = new sendedFirstParamsClass();//请求JSON的第一段
            s1Params.command = 0x00000101;
            s1Params.crc32 = 0;
            s1Params.devId = 566;
            s1Params.sn = 0;

            string json1 = JsonParseTool.ConvertObjToJson(s1Params);
            string json2 = JsonParseTool.ConvertObjToJson(content);
            clientSocket.Send(Encoding.ASCII.GetBytes(json1 + json2));
        }
    }
}
