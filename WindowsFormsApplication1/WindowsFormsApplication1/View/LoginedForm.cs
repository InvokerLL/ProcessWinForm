using System;
using System.Net.Sockets;
using System.Windows.Forms;
using WindowsFormsApplication1.Class;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Tools;

namespace WindowsFormsApplication1.View
{
    public partial class LoginedForm : Form
    {
        public LoginedForm()
        {
            InitializeComponent();
        }
        public Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         
        private void LoginedForm_Load(object sender, EventArgs e)
        {
            RegistryToolClass RJ = new RegistryToolClass();
            RegisterInfoClass Rinfo = new RegisterInfoClass();
            Rinfo = RJ.getRegistInfo();
            label4.Text = Rinfo.ip;
            label5.Text = Rinfo.port;
            label6.Text = Rinfo.name;
           // if (receiveMsg() != 0)
           // {
                ProcessJsonTool PI = new ProcessJsonTool();
                string content = PI.ProcessToJson();
                ProcessJsonPackupClass PJ = new ProcessJsonPackupClass();
                
                PJ.SendProcessMessage(content, clientSocket);

           // }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //删除注册表信息（此处可能还需要加上往数据库发送删除信息）
            RegistryToolClass RJ = new RegistryToolClass();
            RJ.DeleteRegistInfo();
            //回到窗口
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
        private void LoginedForm_Closed(object sender, EventArgs e)
        {
            Application.Run();
        }
        
        public int  receiveMsg()
        {
            byte[] buffer = new byte[1024 * 1024];
            int n = clientSocket.Receive(buffer);
            return n;
           // string backInfo = Encoding.UTF8.GetString(buffer, 0, n);
          //  return backInfo;
        }
        
        }
}
