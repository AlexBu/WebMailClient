﻿namespace WebMailClient
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStripApplication = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewMailBox = new System.Windows.Forms.TreeView();
            this.dataGridViewBoxContent = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerRecv = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSend = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.statusStripApplication.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBoxContent)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMailToolStripMenuItem,
            this.ContactToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.FileToolStripMenuItem.Text = "文件(&F)";
            // 
            // NewMailToolStripMenuItem
            // 
            this.NewMailToolStripMenuItem.Name = "NewMailToolStripMenuItem";
            this.NewMailToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.NewMailToolStripMenuItem.Text = "写邮件(&N)";
            this.NewMailToolStripMenuItem.Click += new System.EventHandler(this.NewMailToolStripMenuItem_Click);
            // 
            // ContactToolStripMenuItem
            // 
            this.ContactToolStripMenuItem.Name = "ContactToolStripMenuItem";
            this.ContactToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ContactToolStripMenuItem.Text = "通讯录(&C)";
            this.ContactToolStripMenuItem.Click += new System.EventHandler(this.ContactToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.EditToolStripMenuItem.Text = "编辑(&E)";
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.DeleteToolStripMenuItem.Text = "删除(&D)";
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ViewToolStripMenuItem.Text = "查看(&V)";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.AboutToolStripMenuItem.Text = "关于(&A)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(791, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStripApplication
            // 
            this.statusStripApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStripApplication.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStripApplication.Location = new System.Drawing.Point(0, 545);
            this.statusStripApplication.Name = "statusStripApplication";
            this.statusStripApplication.Size = new System.Drawing.Size(791, 22);
            this.statusStripApplication.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewMailBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewBoxContent);
            this.splitContainer1.Size = new System.Drawing.Size(791, 496);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeViewMailBox
            // 
            this.treeViewMailBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMailBox.Location = new System.Drawing.Point(0, 0);
            this.treeViewMailBox.Name = "treeViewMailBox";
            this.treeViewMailBox.Size = new System.Drawing.Size(204, 496);
            this.treeViewMailBox.TabIndex = 0;
            this.treeViewMailBox.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMailBox_AfterSelect);
            // 
            // dataGridViewBoxContent
            // 
            this.dataGridViewBoxContent.AllowUserToAddRows = false;
            this.dataGridViewBoxContent.AllowUserToDeleteRows = false;
            this.dataGridViewBoxContent.AllowUserToResizeRows = false;
            this.dataGridViewBoxContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBoxContent.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewBoxContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewBoxContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBoxContent.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBoxContent.Name = "dataGridViewBoxContent";
            this.dataGridViewBoxContent.ReadOnly = true;
            this.dataGridViewBoxContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBoxContent.Size = new System.Drawing.Size(583, 496);
            this.dataGridViewBoxContent.TabIndex = 0;
            this.dataGridViewBoxContent.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewBoxContent_CellMouseDoubleClick);
            // 
            // backgroundWorkerRecv
            // 
            this.backgroundWorkerRecv.WorkerReportsProgress = true;
            this.backgroundWorkerRecv.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRecv_DoWork);
            this.backgroundWorkerRecv.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRecv_RunWorkerCompleted);
            this.backgroundWorkerRecv.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerRecv_ProgressChanged);
            // 
            // backgroundWorkerSend
            // 
            this.backgroundWorkerSend.WorkerReportsProgress = true;
            this.backgroundWorkerSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSend_DoWork);
            this.backgroundWorkerSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerSend_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 567);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStripApplication);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主菜单";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStripApplication.ResumeLayout(false);
            this.statusStripApplication.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBoxContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStripApplication;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewMailBox;
        private System.Windows.Forms.DataGridView dataGridViewBoxContent;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewMailToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRecv;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSend;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}