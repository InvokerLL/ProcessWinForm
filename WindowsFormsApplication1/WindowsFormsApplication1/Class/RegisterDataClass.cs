using System;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApplication1.Class
{
    class Register
    {
        /**获取ip地址*/
        public static string ipTrue()
        {
            string ip = "0.0.0.0";
            System.Net.IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;//IP获取一个LIST里面有一个是IP
            for (int i = 0; i < addressList.Length; i++)
            {
                //判断是否为IP的格式
                if (System.Text.RegularExpressions.Regex.IsMatch(Convert.ToString(addressList[i]), @"((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)") == true)
                {
                    ip = addressList[i].ToString();
                    
                }                         
            }
            return ip;

        }       

        //获取MAC地址
        public static string GetMacAddressByDos()
        {
            string macAddress = "";
            Process p = null;
            StreamReader reader = null;
            try
            {
                ProcessStartInfo start = new ProcessStartInfo("cmd.exe");

                start.FileName = "ipconfig";
                start.Arguments = "/all";

                start.CreateNoWindow = true;

                start.RedirectStandardOutput = true;

                start.RedirectStandardInput = true;

                start.UseShellExecute = false;

                p = Process.Start(start);

                reader = p.StandardOutput;
                //读取当前行
                string line = reader.ReadLine();
                //循环到出现物理地址为止
                while (!reader.EndOfStream)
                {
                    if (line.ToLower().IndexOf("physical address") > 0 || line.ToLower().IndexOf("物理地址") > 0)
                    {
                        int index = line.IndexOf(":");
                        index += 2;
                        macAddress = line.Substring(index);
                        macAddress = macAddress.Replace('-', ':');
                        break;
                    }
                    //不断一个个读取
                    line = reader.ReadLine();
                }
            }
            catch
            {
                //写到错误日志里面去，具体不会写

            }
            finally
            {
                if (p != null)
                {
                    
                    p.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return macAddress;
        }

    }
}
