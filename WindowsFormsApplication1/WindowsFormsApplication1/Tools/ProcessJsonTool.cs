using System;
using System.Collections.Generic;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Class;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Tools
{
    public class ProcessJsonTool
    {
        public string ProcessToJson()
        {
            List<ProcessInfoModel> infos = ProcessInfoClass.GetInfo();
            string json = JsonConvert.SerializeObject(infos);
            return json;

        }
    }
}
