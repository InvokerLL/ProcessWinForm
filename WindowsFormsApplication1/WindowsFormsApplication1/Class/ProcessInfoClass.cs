using System.Collections.Generic;
using WindowsFormsApplication1.Model;
using System.Diagnostics;

namespace WindowsFormsApplication1.Class
{
    public class ProcessInfoClass
    {
        //创建一个List将本机上的进程封装成对象
        public static List<ProcessInfoModel> ProcessInfoModel = new List<ProcessInfoModel>();
        //获取进程
        public static Process[] processes = Process.GetProcesses();
        public static Process process;

        //获取进程信息
        public static List<ProcessInfoModel> GetInfo()
        {
            for (int i = 0; i < processes.Length - 1; i++)
            {
                process = processes[i];
                try
                {
                    string path = process.MainModule.FileName.ToString();
                    FileVersionInfo myInfo = FileVersionInfo.GetVersionInfo(path);
                    ProcessInfoModel infoList = new ProcessInfoModel { content = process.ProcessName + path + myInfo.FileDescription.ToString() };
                    // ProcessInfoModel infoList = new ProcessInfoModel { name = process.ProcessName , path = path, desc = myInfo.FileDescription.ToString() };
                    ProcessInfoModel.Add(infoList);
                }
                catch
                {

                }
            }
            return ProcessInfoModel;
        }
        //关闭对应的线程
        public static void CloseProcess(string processName)
        {
            foreach(Process p in Process.GetProcessesByName(processName))
            {
                try
                {
                    p.CloseMainWindow();
                    p.Kill();
                }
                catch
                {

                }
            }

            
        }
    }

}
