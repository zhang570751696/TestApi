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
                MessageBox.Show("Please input url!", "Warning");
                return;
            }
            if (testThread != null && testThread.IsAlive)
            {
                return;
            }

            ClearLogInfo();
            SiteMapTestBusiness siteMapTestBusiness = new SiteMapTestBusiness(inputUrl);
            siteMapTestBusiness.WriteLogEvent += new WriteLog(WriteLogInfo);
            siteMapTestBusiness.WriteFaliedUrlEvent += new WriteFailedUrl(WriteFaliedUrl);
            testThread = new Thread(siteMapTestBusiness.StartTest);
            testThread.Name = "TestSitemap";
            testThread.IsBackground = true;
            testThread.Start();
            var startInfo = string.Format("Start site map test.the test link is:{0}", inputUrl);
            WriteLogInfo(startInfo);
        }

        public void WriteLogInfo(string logInfo)
        {
            var oldInfo = this.TLogInfo.Text;
            if (string.IsNullOrWhiteSpace(oldInfo))
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.TLogInfo.Text = string.Format("[{0}]:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), logInfo);
                    this.TLogInfo.ScrollToCaret();
                }));
            }
            else
            {
                var newTextInfo = string.Format("{1}{2}[{0}]:{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), oldInfo, Environment.NewLine, logInfo);
                if (newTextInfo.Length > this.TLogInfo.MaxLength)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {

                        this.TLogInfo.Text = string.Format("[{0}]:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), logInfo);
                        this.TLogInfo.ScrollToCaret();
                    }));
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        this.TLogInfo.AppendText(string.Format("{2}[{0}]:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), logInfo, Environment.NewLine));
                        this.TLogInfo.ScrollToCaret();
                    }));
                }
            }

        }

        public void WriteFaliedUrl(string url)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.TFaileUrls.AppendText(string.Format("{0}{1}", Environment.NewLine, url));
            }));
        }

        public void ClearLogInfo()
        {
            this.TLogInfo.Text = string.Empty;
            this.TFaileUrls.Text = string.Empty;
        }

        private void ChooseFolderPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "xml files (*.xml)|*.xml";
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.IndexUrl.Text = dialog.FileName;
            }
        }
    }
}
