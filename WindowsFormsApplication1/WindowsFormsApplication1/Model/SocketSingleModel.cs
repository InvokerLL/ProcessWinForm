using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    public class SocketSingleModel
    {
        private static SocketSingleModel instance;
        private static object _lock = new object();

        private SocketSingleModel()
        {

        }

        public static SocketSingleModel GetInstance()
        {
            if(instance == null)
            {
                lock(_lock)
                {
                    //此处lock里面加if，当两个线程同时进入第一个if，如果lock里面不加if
                    if(instance==null)
                    {
                        instance = new SocketSingleModel();
                    }
                }
            }
            return instance;
        }
    }
}
