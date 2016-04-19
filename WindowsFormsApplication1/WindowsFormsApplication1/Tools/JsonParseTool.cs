using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
/// <summary>
/// 解析JSON工具，仿Javascript风格,JS只能在Web环境下使用
/// </summary>
namespace WindowsFormsApplication1.Tools
{
    public static class JsonParseTool
    {
        /// <summary>  
        /// Converts the obj to json.转化为JSON
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="t">The t.</param>  
        /// <returns>System.String.</returns>  
        /// <remarks>Editor：v-liuhch CreateTime：2016-3-25 15:55:13</remarks>  
        public static string ConvertObjToJson(object t)
        {
            //使用 DataContractJsonSerializer 将 Person 对象序列化为内存流。https://msdn.microsoft.com/zh-cn/library/bb412179.aspx
            DataContractJsonSerializer ser = new DataContractJsonSerializer(t.GetType());

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //使用 WriteObject 方法将 JSON 数据写入到流中。
                    ser.WriteObject(ms, t);
                    string strJson = Encoding.UTF8.GetString(ms.ToArray());
                    return strJson;                   
                }

            }
            catch (IOException)
            {
                //加入自己创建的异常日志中 
                return null;
            }


        }

        /// <summary>  
        /// Jsons the deserialize.反序列化，JSON解析  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="strJson">The STR json.</param>  
        /// <returns>``0.</returns>  
        /// <remarks>Editor：v-liuhch CreateTime：2016-3-25 15:54:59</remarks>  
        public static T JsonDeserialize<T>(string strJson)//  < >貌似里面写的是类
            where T : class 
        {

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(strJson)))
                {
                    T obj = ser.ReadObject(ms) as T;
                    return obj;
                }
            }
            catch (IOException e)
            {
                //写到异常日志中  
                return null;
            }

        }
    }
}
