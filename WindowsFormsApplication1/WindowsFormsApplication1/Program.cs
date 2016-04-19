using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Class;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.View;

namespace WindowsFormsApplication1
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RegistryToolClass RJ = new RegistryToolClass();
           // RJ.DeleteRegistInfo();          
            if (RJ.ExistRegistInfo() == false)
            {
                Application.Run(new Form1());
            }
            else
            {
                //ConnectVerificationController cv = new ConnectVerificationController();
                Application.Run(new LoginedForm());
                
            }       
        }
    }
}
