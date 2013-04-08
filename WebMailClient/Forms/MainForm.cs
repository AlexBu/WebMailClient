using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;

namespace WebMailClient
{
    public partial class MainForm : Form
    {
        private DataTable datatableInbox = null;
        private DataTable datatableOutbox = null;
        private DataTable datatableDraft = null;
        private DataTable datatableRecycle = null;
        private DataTable datatableSentbox = null;
        private DataTable datatableIncome = null;

        enum MAILBOXTYPE
        {
            Inbox = 0,
            Draft = 1,
            Outbox = 2,
            Sentbox = 3,
            Recycle = 4
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // load setting
            LoadSetting();
            // load email database
            LoadEmailDB();
            // init status strip
            InitStatusStrip();
            // load data grid view
            LoadDataGridView();
            // load tree view
            LoadTreeView();
            // get email
            ReceiveEmail();
        }

        private void InitStatusStrip()
        {
            // set status strip
            statusStripApplication.Items[0].Alignment = ToolStripItemAlignment.Right;
        }

        private void ReceiveEmail()
        {
            // receive email from web
            backgroundWorkerRecv.RunWorkerAsync();
        }

        private void LoadDataGridView()
        {
            dataGridViewBoxContent.AutoGenerateColumns = true;
            dataGridViewBoxContent.DataSource = null;
        }

        private void DownloadEmailData(BackgroundWorker worker)
        {
            if (Session.SettingIsValid() == false)
                return;
            // download email data and fill into database
            Pop3 mailbox = new Pop3(Session.Pop3Server, Session.Pop3Port);
            worker.ReportProgress(1, "连接到邮件服务器...");
            mailbox.Connect(Session.AccountName, Session.AccountPass);
            worker.ReportProgress(50, "接收邮件...");
            mailbox.RetrieveEmail(datatableIncome);
            mailbox.DisConnect();
            worker.ReportProgress(99, "从邮件服务器断开");
        }

        private void LoadTreeView()
        {
            treeViewMailBox.Nodes.Clear();
            // add nodes to the tree view
            TreeNode rootNode = new TreeNode(Session.AccountName);
            treeViewMailBox.Nodes.Add(rootNode);
            TreeNode inboxNode = new TreeNode("收件箱");
            rootNode.Nodes.Add(inboxNode);
            TreeNode outboxNode = new TreeNode("发件箱");
            rootNode.Nodes.Add(outboxNode);
            TreeNode draftNode = new TreeNode("草稿箱");
            rootNode.Nodes.Add(draftNode);
            TreeNode recycleNode = new TreeNode("回收站");
            rootNode.Nodes.Add(recycleNode);
            TreeNode sentboxNode = new TreeNode("已发送");
            rootNode.Nodes.Add(sentboxNode);
            rootNode.Expand();

            // select the first item
            treeViewMailBox.SelectedNode = treeViewMailBox.Nodes[0].Nodes[0];
            dataGridViewBoxContent.DataSource = datatableInbox;
        }

        private void LoadEmailDB()
        {
            // load mail data into different datatable
            LoadAllIncomeDB();
            LoadInboxDB();
            LoadOutboxDB();
            LoadDraftDB();
            LoadRecycleDB();
            LoadSentboxDB();
        }

        private void LoadSentboxDB()
        {
            datatableSentbox = new DataTable();
//            string queryStr = String.Format(@"SELECT [UIDL], [DeleteFlag], [From], [Date], [Subject], [Size] 
//                FROM [Mail] WHERE [AccountID] = {0} AND [Folder] = {1}", Session.AccountID, MAILBOXTYPE.Sentbox);
//            DBAccess.FillDataTable(queryStr, ref datatableSentbox);
        }

        private void LoadRecycleDB()
        {
            datatableRecycle = new DataTable();
            string queryStr = String.Format(@"SELECT [UIDL], [From], [Date], [Subject], [Size] 
                FROM [Mail] WHERE ([AccountID] = {0} AND [DeleteFlag] = {1}) ORDER BY [Date] DESC", Session.AccountID, "Yes");
            DBAccess.FillDataTable(queryStr, ref datatableRecycle);
        }

        private void LoadDraftDB()
        {
            datatableDraft = new DataTable();
//            string queryStr = String.Format(@"SELECT [UIDL], [DeleteFlag], [From], [Date], [Subject], [Size] 
//                FROM [Mail] WHERE [AccountID] = {0} AND [Folder] = {1}", Session.AccountID, MAILBOXTYPE.Draft);
//            DBAccess.FillDataTable(queryStr, ref datatableDraft);
        }

        private void LoadOutboxDB()
        {
            datatableOutbox = new DataTable();
//            string queryStr = String.Format(@"SELECT [UIDL], [DeleteFlag], [From], [Date], [Subject], [Size] 
//                FROM [Mail] WHERE [AccountID] = {0} AND [Folder] = {1}", Session.AccountID, MAILBOXTYPE.Outbox);
//            DBAccess.FillDataTable(queryStr, ref datatableOutbox);
        }

        private void LoadInboxDB()
        {
            datatableInbox = new DataTable();
            string queryStr = String.Format(@"SELECT [UIDL], [From], [Date], [Subject], [Size] 
                FROM [Mail] WHERE ([AccountID] = {0} AND [DeleteFlag] = {1}) ORDER BY [Date] DESC", Session.AccountID, "No");
            DBAccess.FillDataTable(queryStr, ref datatableInbox);
        }

        private void LoadAllIncomeDB()
        {
            datatableIncome = new DataTable();
            string queryStr = String.Format(@"SELECT [UIDL], [From], [Date], [Subject], [Size] 
                FROM [Mail] WHERE ([AccountID] = {0}) ORDER BY [Date] DESC", Session.AccountID);
            DBAccess.FillDataTable(queryStr, ref datatableIncome);
        }

        private void treeViewMailBox_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // display content according to the current mailbox
            TreeNode currentNode = treeViewMailBox.SelectedNode;
            if (currentNode.Text == "收件箱")
            {
                // display inbox
                dataGridViewBoxContent.DataSource = datatableInbox;
            }
            else if (currentNode.Text == "发件箱")
            {
                // display outbox
                dataGridViewBoxContent.DataSource = datatableOutbox;
            }
            else if (currentNode.Text == "草稿箱")
            {
                // display draft
                dataGridViewBoxContent.DataSource = datatableDraft;
            }
            else if (currentNode.Text == "回收站")
            {
                // display recycle
                dataGridViewBoxContent.DataSource = datatableRecycle;
            }
            else if (currentNode.Text == "已发送")
            {
                // display sent
                dataGridViewBoxContent.DataSource = datatableSentbox;
            }
            else
            {
                dataGridViewBoxContent.DataSource = null;
            }
            // hide uidl column
            if (dataGridViewBoxContent.ColumnCount >= 1)
            {
                dataGridViewBoxContent.Columns[0].Visible = false;
            }
        }

        private void dataGridViewBoxContent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.Button != MouseButtons.Left)
                return;
            string uidl = dataGridViewBoxContent.Rows[e.RowIndex].Cells[0].Value.ToString();
            // the row being double clicked rather than the selected
            ViewMail(uidl);
        }

        private void ViewMail(string id)
        {
            ViewMail viewMail = new ViewMail();
            viewMail.ID = id;
            viewMail.ShowDialog();

            if (viewMail.DialogResult == DialogResult.OK)
            {
                EditMail editMail = new EditMail();
                editMail.MailBody.AppendText("\n\n\n");
                editMail.MailBody.AppendText("-------------------------------------------");
                editMail.MailBody.AppendText("\n");
                editMail.MailBody.Paste();
                editMail.MailBody.Select(0, 0);
                editMail.Receiver = viewMail.To;
                editMail.Subject = "RE: " + viewMail.Title;
                editMail.ShowDialog();

                if (editMail.DialogResult == DialogResult.OK)
                {
                    backgroundWorkerSend.RunWorkerAsync(editMail);
                }
            }
        }

        private void NewMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open edit mail form to edit email
            EditMail editMail = new EditMail();
            editMail.ShowDialog();
            if (editMail.DialogResult == DialogResult.OK)
            {
                backgroundWorkerSend.RunWorkerAsync(editMail);
            }
        }

        private void backgroundWorkerRecv_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            DownloadEmailData(worker);
        }

        private void backgroundWorkerRecv_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusStripApplication.Items[0].Text = (string)e.UserState;
        }

        private void backgroundWorkerRecv_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
                return;
            if (e.Cancelled == true)
                return;
            // reload inbox data
            LoadInboxDB();
            UpdateInboxGridView();
        }

        private void UpdateInboxGridView()
        {
            // reload datagrid for inbox
            dataGridViewBoxContent.DataSource = datatableInbox;
        }

        private void backgroundWorkerSend_DoWork(object sender, DoWorkEventArgs e)
        {
            EditMail editMail = e.Argument as EditMail;
            MailMessage msg = editMail.MSG;
            SmtpClient client = editMail.Client;
            statusStripApplication.Items[0].Text = "发送邮件...";
            client.Send(msg);
            // also send one copy to local file storage
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            // app dir\mail\user\account\sent\mail list
            string filepath = string.Format("{0}\\Mail\\{1}\\{2}\\Sent\\",
                Directory.GetCurrentDirectory(),
                Session.LoginName,
                Session.AccountName);
            if (Directory.Exists(filepath) == false)
                Directory.CreateDirectory(filepath);
            client.PickupDirectoryLocation = filepath;
            client.EnableSsl = false;
            client.Send(msg);
        }

        private void backgroundWorkerSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusStripApplication.Items[0].Text = "发送邮件成功";
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedMail();
        }

        private void DeleteSelectedMail()
        {
            // set delete flag for selected email

            // check if the current view is inbox
            TreeNode currentNode = treeViewMailBox.SelectedNode;
            if (currentNode.Text == "收件箱")
            {
                DeleteToRecycle();
                LoadInboxDB();
                LoadRecycleDB();
                UpdateInboxGridView();
            }
            else if (currentNode.Text == "回收站")
            {
                DeleteFromServer();
                LoadInboxDB();
                LoadRecycleDB();
                UpdateRecycleGridView();
            }
        }

        private void DeleteFromServer()
        {
            // download email data and fill into database
            Pop3 mailbox = new Pop3(Session.Pop3Server, Session.Pop3Port);
            mailbox.Connect(Session.AccountName, Session.AccountPass);

            foreach (DataGridViewRow row in dataGridViewBoxContent.SelectedRows)
            {
                string uidl = row.Cells[0].Value.ToString();
                if (mailbox.DeleteMail(uidl) == true)
                {
                    // remove the record from database
                    string deleteStr = string.Format("DELETE FROM [Mail] WHERE [UIDL] = '{0}'", uidl);
                    if (DBAccess.ExecuteSQL(deleteStr) == false)
                    {
                        MessageBox.Show("删除邮件失败!", "Webmail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }

            mailbox.DisConnect();
        }

        private void DeleteToRecycle()
        {
            string updateStr = null;
            StringBuilder builder = new StringBuilder();
            // need to process multi rows
            builder.AppendFormat("UPDATE [Mail] SET [DeleteFlag] = {0} WHERE ", "Yes");
            foreach (DataGridViewRow row in dataGridViewBoxContent.SelectedRows)
            {
                builder.AppendFormat("[UIDL] = '{0}' OR ", row.Cells[0].Value.ToString());
            }
            builder.AppendFormat("0");  // meaningless

            updateStr = builder.ToString();
            if (DBAccess.ExecuteSQL(updateStr) == false)
            {
                MessageBox.Show("删除邮件失败!", "Webmail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedMail();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSelectedMail();
        }

        private void OpenSelectedMail()
        {
            // select the first selected mail to display
            int selectedrowscount = dataGridViewBoxContent.SelectedRows.Count;
            if (selectedrowscount > 0)
            {
                string uidl = dataGridViewBoxContent.Rows[0].Cells[0].Value.ToString();
                ViewMail(uidl);
            }
        }

        private void RevertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RevertSelectedMail();
        }

        private void RevertSelectedMail()
        {
            // clear delete flag for selected email

            // check if the current view is inbox
            TreeNode currentNode = treeViewMailBox.SelectedNode;
            if (currentNode.Text != "回收站")
                return;

            string insertStr = null;
            StringBuilder builder = new StringBuilder();
            // need to process multi rows
            builder.AppendFormat("UPDATE [Mail] SET [DeleteFlag] = {0} WHERE ", "No");
            foreach (DataGridViewRow row in dataGridViewBoxContent.SelectedRows)
            {
                builder.AppendFormat("[UIDL] = '{0}' OR ", row.Cells[0].Value.ToString());
            }
            builder.AppendFormat("0");  // meaningless

            insertStr = builder.ToString();
            if (DBAccess.ExecuteSQL(insertStr) == false)
            {
                MessageBox.Show("还原邮件失败!", "Webmail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            LoadInboxDB();
            LoadRecycleDB();
            UpdateRecycleGridView();
        }

        private void UpdateRecycleGridView()
        {
            // reload datagrid for recycle
            dataGridViewBoxContent.DataSource = datatableRecycle;
        }

        private void ContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show contact dialog
            Contact contact = new Contact();
            contact.ShowDialog();
            if (contact.DialogResult == DialogResult.OK)
            {
                // open edit mail form to edit email
                EditMail editMail = new EditMail();
                editMail.Receiver = contact.TO;
                editMail.ShowDialog();
                if (editMail.DialogResult == DialogResult.OK)
                {
                    backgroundWorkerSend.RunWorkerAsync(editMail);
                }
            }
        }

        private void ReceiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiveEmail();
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm settings = new SettingForm();
            LoadSetting();
            settings.ShowDialog();
            if (settings.DialogResult == DialogResult.OK)
            {
                LoadSetting();
                LoadTreeView();
            }
        }

        private void LoadSetting()
        {
            string queryStr = String.Format("SELECT * FROM [Account] WHERE [UserID] = {0}", Session.LoginID);
            // get account
            object[] values = { null, null, null, null, null, null, null, null, null };
            if (DBAccess.QuerySingleRecord(queryStr, ref values) == 9)
            {
                if (values[1] != DBNull.Value)
                    Session.AccountID = (int)values[1];
                if (values[2] != DBNull.Value)
                    Session.AccountName = (string)values[2];
                if (values[3] != DBNull.Value)
                    Session.AccountPass = (string)values[3];
                if (values[4] != DBNull.Value)
                    Session.Pop3Server = (string)values[4];
                if (values[5] != DBNull.Value)
                    Session.Pop3Port = (int)values[5];
                if (values[6] != DBNull.Value)
                    Session.SMTPServer = (string)values[6];
                if (values[7] != DBNull.Value)
                    Session.SMTPPort = (int)values[7];
                if (values[8] != DBNull.Value)
                    Session.MaxEmailCount = (int)values[8];
            }
        }
    }
}
