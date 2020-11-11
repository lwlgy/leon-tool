using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace LeonTools.Common
{
    public class PersistenceHelper
    {
        public static void Save<T>(T items, string saveTo)
        {
            string json = JsonConvert.SerializeObject(items);
            using (StreamWriter sw = new StreamWriter(saveTo, false, Encoding.UTF8))
            {
                sw.Write(json);
                sw.Flush();
                sw.Close();
            }
        }

        public static T Load<T>(string loadFrom)
        {
            using (StreamReader sr = new StreamReader(loadFrom, Encoding.UTF8))
            {
                string json = sr.ReadToEnd();
                sr.Close();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}
