using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var list = HelperUtils.ReadXmlFromUrl(url);
                WriteLogEvent(string.Format("Get href count: {0}", list.Count));
                Task.Run(()=>SendRequest(list));
            }
            catch (Exception ex)
            {
                WriteLogEvent(string.Format("Can not open this url:{0}{1}Exception:{2}", url, Environment.NewLine,ex.Message));
            }
        }

        public async Task SendRequest(List<string> requestUrls)
        {
            if (requestUrls.Any())
            {
                foreach (var requestUrl in requestUrls)
                {
                    var result = await HelperUtils.SendGetRequest(requestUrl);
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
    }
}
