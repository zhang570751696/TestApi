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
            this.GBInputInfo = new System.Windows.Forms.GroupBox();
            this.BtnTest = new System.Windows.Forms.Button();
            this.IndexUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TFaileUrls = new System.Windows.Forms.TextBox();
            this.GBInputInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBInputInfo
            // 
            this.GBInputInfo.Controls.Add(this.BtnTest);
            this.GBInputInfo.Controls.Add(this.IndexUrl);
            this.GBInputInfo.Controls.Add(this.label1);
            this.GBInputInfo.Location = new System.Drawing.Point(14, 12);
            this.GBInputInfo.Name = "GBInputInfo";
            this.GBInputInfo.Size = new System.Drawing.Size(718, 49);
            this.GBInputInfo.TabIndex = 3;
            this.GBInputInfo.TabStop = false;
            this.GBInputInfo.Text = "Input info";
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(631, 15);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(72, 21);
            this.BtnTest.TabIndex = 5;
            this.BtnTest.Text = "Start Test";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // IndexUrl
            // 
            this.IndexUrl.Location = new System.Drawing.Point(155, 16);
            this.IndexUrl.Name = "IndexUrl";
            this.IndexUrl.Size = new System.Drawing.Size(453, 20);
            this.IndexUrl.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please input sitemap index url";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(14, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 171);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(696, 145);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TFaileUrls);
            this.groupBox2.Location = new System.Drawing.Point(14, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 168);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Failed Url";
            // 
            // TFaileUrls
            // 
            this.TFaileUrls.Location = new System.Drawing.Point(7, 20);
            this.TFaileUrls.Multiline = true;
            this.TFaileUrls.Name = "TFaileUrls";
            this.TFaileUrls.ReadOnly = true;
            this.TFaileUrls.Size = new System.Drawing.Size(696, 142);
            this.TFaileUrls.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 424);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GBInputInfo);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TFaileUrls;
    }
}

