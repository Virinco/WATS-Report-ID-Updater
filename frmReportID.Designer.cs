
namespace WATS_UpdateReportIDs
{
    partial class frmReportID
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
            this.components = new System.ComponentModel.Container();
            this.txtSrcSN = new System.Windows.Forms.TextBox();
            this.txtSrcPN = new System.Windows.Forms.TextBox();
            this.txtSrcRev = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDestSN = new System.Windows.Forms.TextBox();
            this.txtDestPN = new System.Windows.Forms.TextBox();
            this.txtDestRev = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.reportIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reportIDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSrcSN
            // 
            this.txtSrcSN.Location = new System.Drawing.Point(88, 12);
            this.txtSrcSN.Name = "txtSrcSN";
            this.txtSrcSN.Size = new System.Drawing.Size(133, 20);
            this.txtSrcSN.TabIndex = 0;
            // 
            // txtSrcPN
            // 
            this.txtSrcPN.Location = new System.Drawing.Point(88, 39);
            this.txtSrcPN.Name = "txtSrcPN";
            this.txtSrcPN.Size = new System.Drawing.Size(133, 20);
            this.txtSrcPN.TabIndex = 1;
            // 
            // txtSrcRev
            // 
            this.txtSrcRev.Location = new System.Drawing.Point(88, 66);
            this.txtSrcRev.Name = "txtSrcRev";
            this.txtSrcRev.Size = new System.Drawing.Size(133, 20);
            this.txtSrcRev.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From SN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "From PN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "From Rev.";
            // 
            // txtDestSN
            // 
            this.txtDestSN.Location = new System.Drawing.Point(88, 109);
            this.txtDestSN.Name = "txtDestSN";
            this.txtDestSN.Size = new System.Drawing.Size(133, 20);
            this.txtDestSN.TabIndex = 3;
            // 
            // txtDestPN
            // 
            this.txtDestPN.Location = new System.Drawing.Point(88, 136);
            this.txtDestPN.Name = "txtDestPN";
            this.txtDestPN.Size = new System.Drawing.Size(133, 20);
            this.txtDestPN.TabIndex = 4;
            // 
            // txtDestRev
            // 
            this.txtDestRev.Location = new System.Drawing.Point(88, 163);
            this.txtDestRev.Name = "txtDestRev";
            this.txtDestRev.Size = new System.Drawing.Size(133, 20);
            this.txtDestRev.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "To SN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "To PN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "To Rev.";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(145, 222);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(64, 222);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // reportIDBindingSource
            // 
            this.reportIDBindingSource.DataSource = typeof(WATS_UpdateReportIDs.ReportID);
            // 
            // frmReportID
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 257);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDestRev);
            this.Controls.Add(this.txtDestPN);
            this.Controls.Add(this.txtSrcRev);
            this.Controls.Add(this.txtDestSN);
            this.Controls.Add(this.txtSrcPN);
            this.Controls.Add(this.txtSrcSN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReportID";
            this.Text = "Update report ID";
            ((System.ComponentModel.ISupportInitialize)(this.reportIDBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSrcSN;
        private System.Windows.Forms.TextBox txtSrcPN;
        private System.Windows.Forms.TextBox txtSrcRev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDestSN;
        private System.Windows.Forms.TextBox txtDestPN;
        private System.Windows.Forms.TextBox txtDestRev;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.BindingSource reportIDBindingSource;
        private System.Windows.Forms.Button btnCancel;
    }
}