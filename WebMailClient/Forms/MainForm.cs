using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

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
            statusStripApplication.Items[0].Alignment = ToolStripItemAlignment.Right;
            // load email database
            LoadEmailDB();
            // load data grid view
            LoadDataGridView();
            // load tree view
            LoadTreeView();
            ReceiveEmail();
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
            // download email data and fill into database
            Pop3 mailbox = new Pop3("pop3.163.com");
            worker.ReportProgress(1, "connecting to mail server");
            mailbox.Connect(Session.AccountName, Session.AccountPass);
            worker.ReportProgress(50, "retrieving email");
            mailbox.RetrieveEmail(datatableIncome);
            mailbox.DisConnect();
            worker.ReportProgress(99, "disconnected from mail server");
        }

        private void LoadTreeView()
        {
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
            string queryStr = String.Format("SELECT [ID], [Accountname], [Accountpass] FROM [Account] WHERE [UserID] = {0}", Session.LoginID);
            // get account
            object[] values = {null, null, null};
            if (DBAccess.QuerySingleRecord(queryStr, ref values) == 3)
            {
                Session.AccountID = (int)values[0];
                Session.AccountName = (string)values[1];
                Session.AccountPass = (string)values[2];
            }

            if (Session.AccountName == null)
                return;

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
            statusStripApplication.Items[0].Text = "sending email";
            client.Send(msg);
        }

        private void backgroundWorkerSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusStripApplication.Items[0].Text = "send success";
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
            Pop3 mailbox = new Pop3("pop3.163.com");
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
    }
}
