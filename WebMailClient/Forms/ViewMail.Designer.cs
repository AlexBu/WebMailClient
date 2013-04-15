namespace WebMailClient
{
    partial class ViewMail
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonReplyMail = new System.Windows.Forms.Button();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxCC = new System.Windows.Forms.TextBox();
            this.textBoxBCC = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.listBoxAttachment = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.webBrowserContent = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "发件人:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "抄送:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "密件:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "主题:";
            // 
            // buttonReplyMail
            // 
            this.buttonReplyMail.Location = new System.Drawing.Point(551, 522);
            this.buttonReplyMail.Name = "buttonReplyMail";
            this.buttonReplyMail.Size = new System.Drawing.Size(75, 23);
            this.buttonReplyMail.TabIndex = 7;
            this.buttonReplyMail.Text = "回复邮件";
            this.buttonReplyMail.UseVisualStyleBackColor = true;
            this.buttonReplyMail.Click += new System.EventHandler(this.buttonReplyMail_Click);
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(131, 3);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.ReadOnly = true;
            this.textBoxFrom.Size = new System.Drawing.Size(510, 20);
            this.textBoxFrom.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFrom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCC, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxBCC, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTitle, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBoxAttachment, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTime, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 197);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // textBoxCC
            // 
            this.textBoxCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCC.Location = new System.Drawing.Point(131, 32);
            this.textBoxCC.Name = "textBoxCC";
            this.textBoxCC.ReadOnly = true;
            this.textBoxCC.Size = new System.Drawing.Size(510, 20);
            this.textBoxCC.TabIndex = 5;
            // 
            // textBoxBCC
            // 
            this.textBoxBCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBCC.Location = new System.Drawing.Point(131, 61);
            this.textBoxBCC.Name = "textBoxBCC";
            this.textBoxBCC.ReadOnly = true;
            this.textBoxBCC.Size = new System.Drawing.Size(510, 20);
            this.textBoxBCC.TabIndex = 6;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTitle.Location = new System.Drawing.Point(131, 90);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(510, 20);
            this.textBoxTitle.TabIndex = 7;
            // 
            // listBoxAttachment
            // 
            this.listBoxAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAttachment.FormattingEnabled = true;
            this.listBoxAttachment.Location = new System.Drawing.Point(131, 148);
            this.listBoxAttachment.Name = "listBoxAttachment";
            this.listBoxAttachment.Size = new System.Drawing.Size(510, 43);
            this.listBoxAttachment.TabIndex = 9;
            this.listBoxAttachment.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxAttachment_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "附件";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "时间:";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTime.Location = new System.Drawing.Point(131, 119);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(510, 20);
            this.textBoxTime.TabIndex = 11;
            // 
            // webBrowserContent
            // 
            this.webBrowserContent.AllowNavigation = false;
            this.webBrowserContent.AllowWebBrowserDrop = false;
            this.webBrowserContent.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserContent.Location = new System.Drawing.Point(13, 227);
            this.webBrowserContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserContent.Name = "webBrowserContent";
            this.webBrowserContent.ScriptErrorsSuppressed = true;
            this.webBrowserContent.Size = new System.Drawing.Size(643, 279);
            this.webBrowserContent.TabIndex = 8;
            // 
            // ViewMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 584);
            this.Controls.Add(this.webBrowserContent);
            this.Controls.Add(this.buttonReplyMail);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ViewMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件查看";
            this.Load += new System.EventHandler(this.ViewMail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonReplyMail;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxCC;
        private System.Windows.Forms.TextBox textBoxBCC;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxAttachment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.WebBrowser webBrowserContent;
    }
}