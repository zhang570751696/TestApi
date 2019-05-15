using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TestSiteMap.Commom.DelegateInfo;

namespace TestSiteMap
{
    public partial class Form1 : Form
    {
        Thread testThread = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            var inputUrl = this.IndexUrl.Text;
            if (string.IsNullOrWhiteSpace(inputUrl))
            {
                MessageBox.Show("Please input url!","Warning");
                return;
            }
            if(testThread != null && testThread.IsAlive)
            {
                return;
            }

            ClearLogInfo();
            SiteMapTestBusiness siteMapTestBusiness = new SiteMapTestBusiness(inputUrl);
            siteMapTestBusiness.WriteLogEvent += new WriteLog(WriteLogInfo);
            testThread = new Thread(siteMapTestBusiness.StartTest);
            testThread.Name = "TestSitemap";
            testThread.IsBackground = true;
            testThread.Start();
            var startInfo = string.Format("[{0}]:Start site map test.the test link is:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), inputUrl);
            WriteLogInfo(startInfo);
        }

        public void WriteLogInfo(string logInfo)
        {
            var oldInfo = this.TLogInfo.Text;
            if (string.IsNullOrWhiteSpace(oldInfo))
            {
                this.TLogInfo.Text = string.Format("{0}", logInfo);
            }
            else
            {
                
                var newTextInfo = string.Format("{0}{1}{2}", oldInfo, Environment.NewLine, logInfo);
                if(newTextInfo.Length > this.TLogInfo.MaxLength)
                {
                    this.TLogInfo.Text = string.Format("{0}", logInfo);
                }
                else
                {
                    this.TLogInfo.Text = string.Format("{0}", newTextInfo);
                }
            }
            
        }

        public void ClearLogInfo()
        {
            this.TLogInfo.Text = string.Empty;
        }
    }
}
