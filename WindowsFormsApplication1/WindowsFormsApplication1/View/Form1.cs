using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Class;
using WindowsFormsApplication1.Tools;
using WindowsFormsApplication1.View;
using System.Threading;

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string ip { get; set; }
        public static string port { get; set; }
        public static string name { get; set; }
        public Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void button1_Click(object sender, EventArgs e)
        {
            //基础信息创建
            ip = textBox1.Text;
            port = textBox2.Text;
            name = textBox3.Text;

            //写入注册表
            RegistryToolClass RJ = new RegistryToolClass();
            RJ.RegistInfo(ip, port, name);
            RegistryKeyClass rk = new RegistryKeyClass();
            //rk.GetRegistData("ip");
            //RegistryKey LMInfo = Registry.LocalMachine;
            

            //验证登录信息
            ConnectVerificationClass cv = new ConnectVerificationClass();
            if (cv.ConnectSever(ip, port, clientSocket) == false)
            {
                return;
            }
            else
            {
                //取得IP和MAC地址
                Register re = new Register();
                ip = Register.ipTrue();
                string mac = Register.GetMacAddressByDos();

                //发送注册请求
                RegistryJsonPackupClass RegistryTool = new RegistryJsonPackupClass();
                RegistryTool.SendRegistryMessage(mac, name, ip, clientSocket);

                //创建线程接受消息
                Thread th = new Thread(receiveMsg);
                th.IsBackground = true;
                th.Start();

                LoginedForm loginedform = new LoginedForm();
                loginedform.ShowDialog();//只是show是不会出现窗体的
                this.Close();
            }
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            Application.Run();
        }


//接受消息并且将JSON解析的方法。
        public void   receiveMsg()
        {
            byte[] buffer = new byte[1024 * 1024];
            int n = clientSocket.Receive(buffer);
            string backInfo = Encoding.UTF8.GetString(buffer, 0, n);

            //需要先拆解字符串,字符串自带"要加一位。
            int index = backInfo.IndexOf("}");
            string strHeader = backInfo.Substring(0, index + 1);
            string strContent = backInfo.Substring(index + 1, backInfo.Length - index - 1);
            strContent = strContent.Substring(0, strContent.IndexOf("}") + 1);            
            BackItemClass back = JsonParseTool.JsonDeserialize<BackItemClass>(strHeader);
            MessageBox.Show(back.ToString());

        }

     
    }
}
