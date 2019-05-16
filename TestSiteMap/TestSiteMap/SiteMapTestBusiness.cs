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
                HttpClient httpClient = new HttpClient();
                var requestUrls = HelperUtils.ReadXmlFromUrl(url);
                WriteLogEvent(string.Format("Get href count: {0}", requestUrls.Count));
                if (requestUrls != null && requestUrls.Any())
                {
                    IEnumerable<Task> tasks = from url in requestUrls select SendRequest(url, httpClient);
                    var requestTask = tasks.ToArray();
                    Task.WaitAll(requestTask);
                }
                WriteLogEvent("Request done!");
            }
            catch (Exception ex)
            {
                WriteLogEvent(string.Format("Can not open this url:{0}{1}Exception:{2}", url, Environment.NewLine, ex.Message));
            }
        }

        public async Task SendRequest(string requestUrl, HttpClient httpClient)
        {
            var result = false;
            try
            {
                var response = await httpClient.GetAsync(requestUrl);
                result = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                result = false;
            }
          
            if (result)
            {
                WriteLogEvent?.Invoke(string.Format("Send request url: {0}, Result: Success", requestUrl));
            }
            else
            {
                WriteFaliedUrlEvent?.Invoke(requestUrl);
            }
        }
    }
}
