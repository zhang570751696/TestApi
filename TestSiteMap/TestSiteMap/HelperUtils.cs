using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestSiteMap
{
    public static class HelperUtils
    {
        /// <summary>
        /// Down load file
        /// </summary>
        /// <param name="url">the url which is download</param>
        /// <returns>load file name</returns>
        public static async Task<string> DownloadFile(string url)
        {
            var filename = url.Split('/').LastOrDefault();

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            try
            {
                using (Stream stream = request.GetResponse().GetResponseStream())
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        byte[] bytes = new byte[1024 * 512];
                        int readCount = 0;
                        while (true)
                        {
                            readCount = await stream.ReadAsync(bytes, 0, bytes.Length);
                            if (readCount <= 0)
                                break;
                            fs.Write(bytes, 0, readCount);
                            fs.Flush();
                        }
                        fs.Close();
                        stream.Close();
                    }
                }
                return filename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<List<string>> ReadXmlFromUrl(string url)
        {
            List<string> fileUrlLists = new List<string>();

            XmlTextReader reader = new XmlTextReader(url);
            while (await reader.ReadAsync())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // the node is an element
                        break;
                    case XmlNodeType.Text:  //Display the text in each element.
                        fileUrlLists.Add(reader.Value);
                        break;
                    case XmlNodeType.EndElement: // Display the end of the element
                        break;
                }
            }

            return fileUrlLists;
        }
    }
}
