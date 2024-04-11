
namespace WATS_UpdateReportIDs
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.txtServiceURL = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSkipHeader = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtServiceURL
            // 
            this.txtServiceURL.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WATS_UpdateReportIDs.Properties.Settings.Default, "ServiceURL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtServiceURL.Location = new System.Drawing.Point(133, 12);
            this.txtServiceURL.Name = "txtServiceURL";
            this.txtServiceURL.Size = new System.Drawing.Size(259, 20);
            this.txtServiceURL.TabIndex = 0;
            this.txtServiceURL.Text = global::WATS_UpdateReportIDs.Properties.Settings.Default.ServiceURL;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(133, 39);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(259, 20);
            this.txtToken.TabIndex = 1;
            this.txtToken.Text = global::WATS_UpdateReportIDs.Properties.Settings.Default.Token;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(14, 15);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(68, 13);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "Service URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Token";
            // 
            // chkSkipHeader
            // 
            this.chkSkipHeader.AutoSize = true;
            this.chkSkipHeader.Location = new System.Drawing.Point(133, 91);
            this.chkSkipHeader.Name = "chkSkipHeader";
            this.chkSkipHeader.Size = new System.Drawing.Size(103, 17);
            this.chkSkipHeader.TabIndex = 8;
            this.chkSkipHeader.Text = "Skip header row";
            this.chkSkipHeader.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(317, 147);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(133, 65);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(259, 20);
            this.txtDelimiter.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CSV Delimiter";
            // 
            // frmSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(404, 182);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkSkipHeader);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtServiceURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServiceURL;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSkipHeader;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label label3;
    }
}