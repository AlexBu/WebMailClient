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
            this.textBoxAttachment = new System.Windows.Forms.TextBox();
            this.buttonSendMail = new System.Windows.Forms.Button();
            this.buttonSaveDraft = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxContent
            // 
            this.richTextBoxContent.Location = new System.Drawing.Point(43, 222);
            this.richTextBoxContent.Name = "richTextBoxContent";
            this.richTextBoxContent.Size = new System.Drawing.Size(641, 293);
            this.richTextBoxContent.TabIndex = 0;
            this.richTextBoxContent.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxReceive, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCC, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxBCC, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTitle, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAttachment, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(43, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.55319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.44681F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 173);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "收件:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "抄送:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "密件:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "主题:";
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Location = new System.Drawing.Point(325, 3);
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.Size = new System.Drawing.Size(100, 20);
            this.textBoxReceive.TabIndex = 4;
            // 
            // textBoxCC
            // 
            this.textBoxCC.Location = new System.Drawing.Point(325, 30);
            this.textBoxCC.Name = "textBoxCC";
            this.textBoxCC.Size = new System.Drawing.Size(100, 20);
            this.textBoxCC.TabIndex = 5;
            // 
            // textBoxBCC
            // 
            this.textBoxBCC.Location = new System.Drawing.Point(325, 67);
            this.textBoxBCC.Name = "textBoxBCC";
            this.textBoxBCC.Size = new System.Drawing.Size(100, 20);
            this.textBoxBCC.TabIndex = 6;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(325, 101);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxTitle.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "附件";
            // 
            // textBoxAttachment
            // 
            this.textBoxAttachment.Location = new System.Drawing.Point(325, 140);
            this.textBoxAttachment.Name = "textBoxAttachment";
            this.textBoxAttachment.Size = new System.Drawing.Size(100, 20);
            this.textBoxAttachment.TabIndex = 9;
            // 
            // buttonSendMail
            // 
            this.buttonSendMail.Location = new System.Drawing.Point(582, 531);
            this.buttonSendMail.Name = "buttonSendMail";
            this.buttonSendMail.Size = new System.Drawing.Size(75, 23);
            this.buttonSendMail.TabIndex = 2;
            this.buttonSendMail.Text = "发送";
            this.buttonSendMail.UseVisualStyleBackColor = true;
            this.buttonSendMail.Click += new System.EventHandler(this.buttonSendMail_Click);
            // 
            // buttonSaveDraft
            // 
            this.buttonSaveDraft.Location = new System.Drawing.Point(492, 531);
            this.buttonSaveDraft.Name = "buttonSaveDraft";
            this.buttonSaveDraft.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveDraft.TabIndex = 3;
            this.buttonSaveDraft.Text = "保存为草稿";
            this.buttonSaveDraft.UseVisualStyleBackColor = true;
            // 
            // EditMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 572);
            this.Controls.Add(this.buttonSaveDraft);
            this.Controls.Add(this.buttonSendMail);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.richTextBoxContent);
            this.Name = "EditMail";
            this.Text = "邮件编写";
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
        private System.Windows.Forms.Button buttonSendMail;
        private System.Windows.Forms.Button buttonSaveDraft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAttachment;
    }
}