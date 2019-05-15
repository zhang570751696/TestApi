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

        public SiteMapTestBusiness(string url)
        {
            this.url = url;
        }

        public void StartTest()
        {

        }
    }
}
