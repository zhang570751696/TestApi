using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestSiteMap
{
    public static class HelperUtils
    {
        public static async Task DownloadFile(string url)
        {
            var filename = url.Split('/').LastOrDefault();

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            Stream stream = request.GetResponse().GetResponseStream();

            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            byte[] bytes = new byte[1024 * 512];
            int readCount = 0;
            while (true)
            {
                readCount = stream.Read(bytes, 0, bytes.Length);
                if (readCount <= 0)
                    break;
                fs.Write(bytes, 0, readCount);
                fs.Flush();
            }
            fs.Close();
            stream.Close();
        }
    }
}
