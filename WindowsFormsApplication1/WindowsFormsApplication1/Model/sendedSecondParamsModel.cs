using System.Runtime.Serialization;

namespace WindowsFormsApplication1.Model
{
    [DataContract]//指定该类型可以序列化，必不可少
    class sendedSecondParamsClass
    {
        /**MAC地址*/
        [DataMember]//缺少这个转换出来为空
        public  string MacAddr { get; set; }

        /**服务器返回的名字*/
        [DataMember]
        public string DevName { get; set; }

        /**IP地址*/
        [DataMember]
        public string IpAddr { get; set; }

        /**服务器返回的ID*/
        [DataMember]
        public int devId { get; set; }


    }
}
