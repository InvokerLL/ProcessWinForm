using WindowsFormsApplication1.Class;

namespace WindowsFormsApplication1.BusinessProcess
{
    public class CloseSoftwareController
    {
       public  void closeProcess(string processName)
        {
            ProcessInfoClass.CloseProcess(processName);
        }
    
    }
}
