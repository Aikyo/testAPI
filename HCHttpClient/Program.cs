﻿using Newtonsoft.Json;
using System;

namespace HCHttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //string result = HttpClientHelper.GetResponse("https://localhost:44345/Reservation/FYProduct?ProductId=CP100046");
            //Console.WriteLine(result);
            //FYProductDto pro = HttpClientHelper.GetResponse<FYProductDto>("https://localhost:44345/Reservation/FYProduct?ProductId=CP100046");
            //string prostr = JsonConvert.SerializeObject(pro);
            //Console.WriteLine(pro.ProductId + pro.ProductName);
            //Console.WriteLine(prostr + "prostr");

            //CancelDto cancel = new CancelDto();
            //cancel.OrderId = 3;
            //cancel.status = OrderStatus.取消预约;

            //HttpClientHelper.PostResponse("https://localhost:44345/Reservation/Alter",cancel);
            //string s = new string("duoduo");
            //string ss = HttpClientHelper.PostResponse("https://localhost:44340/MitzuNomo/Say", s);
            
            //string sss = HttpClientHelper.GetResponse("https://localhost:44345/Reservation/Alert");
            //Console.WriteLine("-------"+ sss);

            //string ss = HttpClientHelper.GetResponse("http://localhost:44340/MitzuNomo/string");
            //Console.WriteLine(ss);

            string url = "https://localhost:44373/api/Values/IP?Id=78&name=herman";
            string result = HttpClientHelper.GetResponse(url);
            Console.WriteLine(result);

            string url1 = "https://localhost:44373/api/Values/ReadPost";
            string result1 = HttpServices.Post(url1, "<xml><name>herman</name></xml>");
            Console.WriteLine(result1);
        }
    }
}
