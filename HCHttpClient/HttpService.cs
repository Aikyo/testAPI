using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HCHttpClient
{
    public class HttpServices
    {
        /// <summary>
        /// Post请求返回实体 
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">请求数据</param>
        /// <returns>实体</returns>
        public static string Post(string url, string postData)
        {
            HttpClient httpClient = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip });
            HttpResponseMessage response = null;
            try
            {
                httpClient.MaxResponseContentBufferSize = 256000;
                httpClient.CancelPendingRequests();
                httpClient.DefaultRequestHeaders.Clear();
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
                string result = null;
                Task<HttpResponseMessage> taskResponse = httpClient.PostAsync(url, httpContent);
                taskResponse.Wait();
                response = taskResponse.Result;
                //using (HttpResponseMessage response = taskResponse.Result)
                //{
                //HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    Task<System.IO.Stream> taskStream = response.Content.ReadAsStreamAsync();
                    taskStream.Wait();
                    System.IO.Stream dataStream = taskStream.Result;
                    System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
                    result = reader.ReadToEnd();
                }
                return result;
            }
            catch
            {
                return "";
            }
            finally
            {
                response?.Dispose();
                if (httpClient != null)
                {
                    httpClient.Dispose();

                }

            }

        }
    }
}
