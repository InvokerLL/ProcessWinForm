using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Class
{
    class RegistryToolClass
    {
        RegistryKeyClass Hengshu = new RegistryKeyClass();
        //判断是否为64位
        RegisterInfoClass Info = new RegisterInfoClass();

        //各类信息到注册表
        public void RegistInfo(string ip_out, string port_out, string name_out)
        {
                Hengshu.WTRegedit("ip", ip_out);
                Hengshu.WTRegedit("port", port_out);
                Hengshu.WTRegedit("name", name_out);
        }
        //得到注册表信息
        public RegisterInfoClass getRegistInfo()
        {
           
           Info.ip = Hengshu.GetRegistData("ip");
           Info.port = Hengshu.GetRegistData("port");
           Info.name = Hengshu.GetRegistData("name");
           return Info;
        }

    
        //判断是否存在注册信息
        public bool ExistRegistInfo()
        {            
                //存在hengshu文件夹，且存在ip,port,name
                if (Hengshu.IsRegeditExist("ip") && Hengshu.IsRegeditExist("port") && Hengshu.IsRegeditExist("name"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        /// <summary>
        ///注销注册信息
        /// </summary>
        public void DeleteRegistInfo()
        {
            Hengshu.DeleteRegist("ip");
            Hengshu.DeleteRegist("port");
            Hengshu.DeleteRegist("name");
        }
      


    }
}
