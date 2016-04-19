using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Class
{
    class RegistryKeyClass
    {

        //创建横竖文件夹
        public void createHengshu()
        {
            if (Environment.Is64BitOperatingSystem == true)
            {
                RegistryKey LMInfo = Registry.LocalMachine;
                RegistryKey software = LMInfo.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                software.CreateSubKey("hengshu");
            }
            else
            {
                MessageBox.Show("该电脑为32位版本请安装32位版本");
            }
        }

        //判断是否有横竖文件夹
        public bool existHengshu()
        {
            bool _existHenshu = false;
            try
            {
                if (Environment.Is64BitOperatingSystem == true)
                {
                    string[] subkeyNames;
                    RegistryKey LMInfo = Registry.LocalMachine;
                    RegistryKey software = LMInfo.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                    subkeyNames = software.GetSubKeyNames();
                    foreach (string keyName in subkeyNames)
                    {
                        if (keyName == "hengshu")
                        {
                            _existHenshu = true;
                            return _existHenshu;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("该电脑为32位版本请安装32位版本");


                }
            }
            catch
            { }
            return _existHenshu;

        }

        //读取指定名称的注册表的值
        public string GetRegistData(string name)
        {
            if (Environment.Is64BitOperatingSystem == true)
            {
                string registData;
                RegistryKey LMInfo = Registry.LocalMachine;
                RegistryKey software = LMInfo.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl); //以上是读取的注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下的XXX目录中名称为name的注册表值；
                RegistryKey myName = software.OpenSubKey("hengshu", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                registData = myName.GetValue(name).ToString();
                return registData;
            }
            else
            {
                MessageBox.Show("该电脑为32位版本请安装32位版本");
                return null;

            }
        }

        //向注册表里写东西
        public void WTRegedit(string name, string tovalue)
        {
            if (Environment.Is64BitOperatingSystem == true)
            {
                RegistryKey LMInfo = Registry.LocalMachine;
                RegistryKey software = LMInfo.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                RegistryKey myName = software.CreateSubKey("hengshu", RegistryKeyPermissionCheck.ReadWriteSubTree);
                myName.SetValue(name, tovalue);
            }
            else
            {
                MessageBox.Show("该电脑为32位版本请安装32位版本");

            }
        }

        //删除注册表里hengshu文件夹中的指定字段
        public void DeleteRegist(string name)
        {
            try
            {
                if (Environment.Is64BitOperatingSystem == true)
                {
                    string[] myNames;
                    RegistryKey LMInfo = Registry.LocalMachine;
                    RegistryKey software = LMInfo.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                    RegistryKey myName = software.OpenSubKey("hengshu", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                    //这里是删除指定字段的方法,因为注册表涉及到开关机，还有诸多后台操作，不能瞎比删
                    myNames = myName.GetValueNames();
                    foreach (string keyName in myNames)
                    {
                        if (keyName == name)
                        {//只有deleteValue才会删除指定字段，其他是删除文件夹没有任何作用
                            myName.DeleteValue(name);//是在注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下XXX目录中删除名称为name注册表项；                            
                        }
                        }
                }
                else
                {
                    MessageBox.Show("该电脑为32位版本请安装32位版本");

                }
            }
            catch { }
           
        }

        //判断指定注册表是否存在
        public bool IsRegeditExist(string name)
        {
            bool _exist = false;
            try
            {
                if (Environment.Is64BitOperatingSystem == true)
                {
                    string[] subkeyNames;
                    RegistryKey LMInfo = Registry.LocalMachine;
                    RegistryKey software = LMInfo.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                    RegistryKey myName = software.OpenSubKey("hengshu", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                    subkeyNames = myName.GetValueNames();
                    foreach (string keyName in subkeyNames)
                    {
                        if (keyName == name)
                        {
                            _exist = true;
                            return _exist;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("该电脑为32位版本请安装32位版本");
                }
            }
            catch
            { }
            return _exist;//HKEY_LOCAL_MACHINE\SOFTWARE目录下XXX目录中判断名称为name注册表项是否存在，这一方法在删除注册表时已经存在，在新建一注册表项时也应有相应判断；  
        }




    }
}
