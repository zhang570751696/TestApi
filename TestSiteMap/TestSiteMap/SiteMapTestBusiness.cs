using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static TestSiteMap.Commom.DelegateInfo;

namespace TestSiteMap
{
    public class SiteMapTestBusiness
    {
        private readonly string url;
        public event WriteLog WriteLogEvent;
        public event WriteFailedUrl WriteFaliedUrlEvent;

        public SiteMapTestBusiness(string url)
        {
            this.url = url;
        }

        public void StartTest()
        {
            try
            {
                var requestUrls = HelperUtils.ReadXmlFromUrl(url);
                WriteLogEvent?.Invoke(string.Format("Get href count: {0}", requestUrls.Count));
                if (requestUrls != null && requestUrls.Any())
                {
                    IEnumerable<Task> tasks = from url in requestUrls select SendRequest(url);
                    var requestTask = tasks.ToArray();
                    Task.WaitAll(requestTask);
                }
                WriteLogEvent?.Invoke("Request done!");
            }
            catch (Exception ex)
            {
                WriteLogEvent?.Invoke(string.Format("Can not open this url:{0}{1}Exception:{2}", url, Environment.NewLine, ex.Message));
            }
        }

        public async Task SendRequest(string requestUrl)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(requestUrl);
                    var result = response.IsSuccessStatusCode;
                    WriteLogEvent?.Invoke(string.Format("Send request url: {0}, Result: {1}, ResponseCode:{2}", requestUrl, response.IsSuccessStatusCode ? "Success" : "Falied", response.StatusCode.ToString()));
                    if (!response.IsSuccessStatusCode)
                    {
                        WriteFaliedUrlEvent?.Invoke(requestUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogEvent?.Invoke(string.Format("Send request url: {0}, Result: Failed, Because error has happend:{1}", requestUrl, ex.ToString()));
                WriteFaliedUrlEvent?.Invoke(requestUrl);
            }
        }
    }
}
