namespace TestSiteMap
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GBInputInfo = new System.Windows.Forms.GroupBox();
            this.BtnTest = new System.Windows.Forms.Button();
            this.IndexUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TLogInfo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TFaileUrls = new System.Windows.Forms.TextBox();
            this.GBInputInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBInputInfo
            // 
            resources.ApplyResources(this.GBInputInfo, "GBInputInfo");
            this.GBInputInfo.Controls.Add(this.BtnTest);
            this.GBInputInfo.Controls.Add(this.IndexUrl);
            this.GBInputInfo.Controls.Add(this.label1);
            this.GBInputInfo.Name = "GBInputInfo";
            this.GBInputInfo.TabStop = false;
            // 
            // BtnTest
            // 
            resources.ApplyResources(this.BtnTest, "BtnTest");
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // IndexUrl
            // 
            resources.ApplyResources(this.IndexUrl, "IndexUrl");
            this.IndexUrl.Name = "IndexUrl";
            this.IndexUrl.Click += new System.EventHandler(this.ChooseFolderPath_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.TLogInfo);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // TLogInfo
            // 
            resources.ApplyResources(this.TLogInfo, "TLogInfo");
            this.TLogInfo.Name = "TLogInfo";
            this.TLogInfo.ReadOnly = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.TFaileUrls);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // TFaileUrls
            // 
            resources.ApplyResources(this.TFaileUrls, "TFaileUrls");
            this.TFaileUrls.Name = "TFaileUrls";
            this.TFaileUrls.ReadOnly = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBInputInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.GBInputInfo.ResumeLayout(false);
            this.GBInputInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBInputInfo;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.TextBox IndexUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TLogInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TFaileUrls;
    }
}

