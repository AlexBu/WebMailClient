namespace WebMailClient
{
    partial class EditMail
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
            this.richTextBoxContent = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.textBoxCC = new System.Windows.Forms.TextBox();
            this.textBoxBCC = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxAttachment = new System.Windows.Forms.ListBox();
            this.buttonSaveDraft = new System.Windows.Forms.Button();
            this.buttonAddAttachment = new System.Windows.Forms.Button();
            this.buttonRemoveAttachment = new System.Windows.Forms.Button();
            this.buttonSendMail = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxContent
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBoxContent, 2);
            this.richTextBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxContent.Location = new System.Drawing.Point(8, 252);
            this.richTextBoxContent.Name = "richTextBoxContent";
            this.richTextBoxContent.Size = new System.Drawing.Size(763, 241);
            this.richTextBoxContent.TabIndex = 0;
            this.richTextBoxContent.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.buttonRemoveAttachment, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddAttachment, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxReceive, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCC, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxBCC, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTitle, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.listBoxAttachment, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxContent, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveDraft, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonSendMail, 1, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(779, 560);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "收件:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "抄送:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "密件:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "主题:";
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxReceive.Location = new System.Drawing.Point(161, 8);
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.Size = new System.Drawing.Size(610, 20);
            this.textBoxReceive.TabIndex = 4;
            // 
            // textBoxCC
            // 
            this.textBoxCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCC.Location = new System.Drawing.Point(161, 35);
            this.textBoxCC.Name = "textBoxCC";
            this.textBoxCC.Size = new System.Drawing.Size(610, 20);
            this.textBoxCC.TabIndex = 5;
            // 
            // textBoxBCC
            // 
            this.textBoxBCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBCC.Location = new System.Drawing.Point(161, 62);
            this.textBoxBCC.Name = "textBoxBCC";
            this.textBoxBCC.Size = new System.Drawing.Size(610, 20);
            this.textBoxBCC.TabIndex = 6;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTitle.Location = new System.Drawing.Point(161, 89);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(610, 20);
            this.textBoxTitle.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "附件";
            // 
            // listBoxAttachment
            // 
            this.listBoxAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAttachment.FormattingEnabled = true;
            this.listBoxAttachment.Location = new System.Drawing.Point(161, 116);
            this.listBoxAttachment.Name = "listBoxAttachment";
            this.listBoxAttachment.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxAttachment.Size = new System.Drawing.Size(610, 69);
            this.listBoxAttachment.TabIndex = 9;
            // 
            // buttonSaveDraft
            // 
            this.buttonSaveDraft.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSaveDraft.Location = new System.Drawing.Point(696, 499);
            this.buttonSaveDraft.Name = "buttonSaveDraft";
            this.buttonSaveDraft.Size = new System.Drawing.Size(75, 21);
            this.buttonSaveDraft.TabIndex = 3;
            this.buttonSaveDraft.Text = "保存为草稿";
            this.buttonSaveDraft.UseVisualStyleBackColor = true;
            this.buttonSaveDraft.Click += new System.EventHandler(this.buttonSaveDraft_Click);
            // 
            // buttonAddAttachment
            // 
            this.buttonAddAttachment.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddAttachment.Location = new System.Drawing.Point(696, 198);
            this.buttonAddAttachment.Name = "buttonAddAttachment";
            this.buttonAddAttachment.Size = new System.Drawing.Size(75, 21);
            this.buttonAddAttachment.TabIndex = 4;
            this.buttonAddAttachment.Text = "添加附件";
            this.buttonAddAttachment.UseVisualStyleBackColor = true;
            this.buttonAddAttachment.Click += new System.EventHandler(this.buttonAddAttachment_Click);
            // 
            // buttonRemoveAttachment
            // 
            this.buttonRemoveAttachment.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRemoveAttachment.Location = new System.Drawing.Point(696, 225);
            this.buttonRemoveAttachment.Name = "buttonRemoveAttachment";
            this.buttonRemoveAttachment.Size = new System.Drawing.Size(75, 21);
            this.buttonRemoveAttachment.TabIndex = 5;
            this.buttonRemoveAttachment.Text = "删除附件";
            this.buttonRemoveAttachment.UseVisualStyleBackColor = true;
            this.buttonRemoveAttachment.Click += new System.EventHandler(this.buttonRemoveAttachment_Click);
            // 
            // buttonSendMail
            // 
            this.buttonSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendMail.Location = new System.Drawing.Point(696, 526);
            this.buttonSendMail.Name = "buttonSendMail";
            this.buttonSendMail.Size = new System.Drawing.Size(75, 25);
            this.buttonSendMail.TabIndex = 2;
            this.buttonSendMail.Text = "发送";
            this.buttonSendMail.UseVisualStyleBackColor = true;
            this.buttonSendMail.Click += new System.EventHandler(this.buttonSendMail_Click);
            // 
            // EditMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 560);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件编写";
            this.Load += new System.EventHandler(this.EditMail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxReceive;
        private System.Windows.Forms.TextBox textBoxCC;
        private System.Windows.Forms.TextBox textBoxBCC;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonSaveDraft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddAttachment;
        private System.Windows.Forms.Button buttonRemoveAttachment;
        private System.Windows.Forms.ListBox listBoxAttachment;
        private System.Windows.Forms.Button buttonSendMail;
    }
}