namespace WebMailClient
{
    partial class Contact
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
            this.dataGridViewContact = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataSetContact = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetContact)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewContact
            // 
            this.dataGridViewContact.AllowUserToAddRows = false;
            this.dataGridViewContact.AllowUserToDeleteRows = false;
            this.dataGridViewContact.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewContact.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewContact.Name = "dataGridViewContact";
            this.dataGridViewContact.ReadOnly = true;
            this.dataGridViewContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContact.Size = new System.Drawing.Size(447, 366);
            this.dataGridViewContact.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "邮件地址";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "备注";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(492, 98);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(492, 150);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "删除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(492, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "查找";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(492, 50);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 7;
            this.buttonSend.Text = "发送邮件";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(12, 13);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(447, 20);
            this.textBoxSearch.TabIndex = 8;
            // 
            // dataSetContact
            // 
            this.dataSetContact.DataSetName = "DataSetContact";
            // 
            // Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 428);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewContact);
            this.Name = "Contact";
            this.Text = "联系人";
            this.Load += new System.EventHandler(this.Contact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewContact;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Data.DataSet dataSetContact;
    }
}