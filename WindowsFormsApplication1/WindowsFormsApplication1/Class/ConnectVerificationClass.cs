using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Class
{
    class ConnectVerificationClass
    {
        public bool ConnectSever(string ip, string port, Socket clientSocket)
        {
            //判断IP格式
            if (System.Text.RegularExpressions.Regex.IsMatch(ip, @"((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)") == false)
            {
                MessageBox.Show("请输入正确的IP地址！");
                return false;
            }

            //判断端口号格式
            int portInfo;
            if (int.TryParse(port, out portInfo) == false || Convert.ToInt32(port) > 65535 || Convert.ToInt32(port) <= 0)
            {
                MessageBox.Show("端口号为大于0小于65535的数字，请重新输入");
                return false;
            }

            //连接到服务器上
            IPAddress ipInfo = IPAddress.Parse(ip);
            //Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ipInfo, Convert.ToInt32(port)));
                MessageBox.Show("服务器连接成功!");
                return true;
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message, "错误");
                return false;
            }
        }
    }
}
