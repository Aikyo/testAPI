using System;
using System.Collections.Generic;

namespace Communication
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://localhost:44373/api/Values/IP?Id=78&name=herman";
            string result = HttpClientHelper.GetResponse(url);
            Console.WriteLine(result);

            string url1 = "https://localhost:44373/api/Values/ReadPost";
            string result1 = HttpService.Post(url1, "<xml><name>herman</name></xml>");
            Console.WriteLine(result1);

            string url2 = "https://localhost:44373/api/Values/Getobject";
            Dictionary<string,object> dic = HttpClientHelper.GetResponse<Dictionary<string,object>>(url2);
            string s = "";
            object o = null;
            if (dic != null)
            {
                bool b = dic.TryGetValue("war", out o);
                if (b == true)
                {
                    s = o.ToString();
                }
            }
            Console.WriteLine(s);
            Console.WriteLine(GenerateTimeStamp());

            Console.WriteLine("---------------------------------");
            string url3 = "https://localhost:44365/Home/response";
            string re3 = HttpService.Post(url1, "<xml><name>kikiki</name></xml>");
            
            Console.WriteLine(re3);

            Console.WriteLine("---writeresponse------------------------------");
            string url4 = "https://localhost:44365/Home/writeResponse";
            string re4 = HttpService.Post(url4, "<xml><name>kikiki</name></xml>");

            


        }

        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

    }
}
