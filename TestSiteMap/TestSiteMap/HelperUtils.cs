﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestSiteMap
{
    public static class HelperUtils
    {

        private static HttpClient client = new HttpClient();
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
        public static List<string> ReadXmlFromUrl(string url)
        {
            List<string> fileUrlLists = new List<string>();


            XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // the node is an element
                        if (reader.Name == "loc")
                        {
                            var value = reader.ReadElementString();
                            if (!fileUrlLists.Contains(value))
                            {
                                fileUrlLists.Add(value);
                            }

                        }
                        if (reader.Name == "xhtml:link")
                        {
                            var relValue = reader.GetAttribute("rel");
                            var hrefValue = reader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(hrefValue))
                            {
                                if (!fileUrlLists.Contains(hrefValue))
                                {
                                    fileUrlLists.Add(hrefValue);
                                }
                            }
                        }
                        break;
                    case XmlNodeType.Text:  //Display the text in each element.
                        break;
                    case XmlNodeType.EndElement: // Display the end of the element
                        break;
                }
            }

            return fileUrlLists;
        }

        public static async Task<bool> SendGetRequest(string url)
        {
            try
            {
                var responseMessage = await client.GetAsync(url);
                return responseMessage.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
