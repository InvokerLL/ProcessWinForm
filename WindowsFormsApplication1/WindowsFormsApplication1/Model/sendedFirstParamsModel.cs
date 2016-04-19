using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    [DataContract]
    class sendedFirstParamsClass
    {
        /**命令*/
        [DataMember]
        public  int command { get; set; }

        /**不知道啥玩意*/
        [DataMember]
        public  int crc32 { get; set; }

        /**服务器返回的ID*/
        [DataMember]
        public  int devId { get; set; }

        /**任务号*/
        [DataMember]
        public  int sn { get; set; }

    }

}
