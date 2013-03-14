using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebMailClient
{
    public partial class MainForm : Form
    {
        private DataTable datatableInbox = null;
        private DataTable datatableOutbox = null;
        private DataTable datatableDraft = null;
        private DataTable datatableRecycle = null;
        private DataTable datatableSentbox = null;

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
            // load email database
            LoadEmailDB();
            // load data grid view
            LoadDataGridView();
            // load tree view
            LoadTreeView();
            // receive email from web
            DownloadEmailData();
        }

        private void LoadDataGridView()
        {
            dataGridViewBoxContent.AutoGenerateColumns = true;
            dataGridViewBoxContent.DataSource = null;
            dataGridViewBoxContent.AutoResizeColumns();
        }

        private void DownloadEmailData()
        {
            // download email data and fill into database
            Pop3 mailbox = new Pop3("pop3.163.com");
            mailbox.Connect(Session.AccountName, Session.AccountPass);
            mailbox.RetrieveEmail(datatableInbox);
            mailbox.DisConnect();
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
            LoadInboxDB();
            LoadOutboxDB();
            LoadDraftDB();
            LoadRecycleDB();
            LoadSentboxDB();
        }

        private void LoadSentboxDB()
        {
            datatableSentbox = new DataTable();
            string queryStr = String.Format(@"SELECT [ID], [UIDL], [ReadFlag] 
                FROM [Mail] WHERE [AccountID] = {0} AND [Folder] = {1}", Session.AccountID, MAILBOXTYPE.Sentbox);
            DBAccess.FillDataTable(queryStr, ref datatableSentbox);
        }

        private void LoadRecycleDB()
        {
            datatableRecycle = new DataTable();
            string queryStr = String.Format(@"SELECT [ID], [UIDL], [ReadFlag] 
                FROM [Mail] WHERE [AccountID] = {0} AND [Folder] = {1}", Session.AccountID, MAILBOXTYPE.Recycle);
            DBAccess.FillDataTable(queryStr, ref datatableRecycle);
        }

        private void LoadDraftDB()
        {
            datatableDraft = new DataTable();
            string queryStr = String.Format(@"SELECT [ID], [UIDL], [ReadFlag] 
                FROM [Mail] WHERE [AccountID] = {0} AND [Folder] = {1}", Session.AccountID, MAILBOXTYPE.Draft);
            DBAccess.FillDataTable(queryStr, ref datatableDraft);
        }

        private void LoadOutboxDB()
        {
            datatableOutbox = new DataTable();
            string queryStr = String.Format(@"SELECT [ID], [UIDL], [ReadFlag] 
                FROM [Mail] WHERE [AccountID] = {0} AND [Folder] = {1}", Session.AccountID, MAILBOXTYPE.Outbox);
            DBAccess.FillDataTable(queryStr, ref datatableOutbox);
        }

        private void LoadInboxDB()
        {
            datatableInbox = new DataTable();
            string queryStr = String.Format(@"SELECT [ID], [UIDL], [ReadFlag] 
                FROM [Mail] WHERE [AccountID] = {0} AND [Folder] = {1}", Session.AccountID, (int)MAILBOXTYPE.Inbox);
            DBAccess.FillDataTable(queryStr, ref datatableInbox);
        }

        private void ContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show contact dialog
            Contact contact = new Contact();
            contact.ShowDialog();
        }

        public bool IsEmailDownloaded(string uidl)
        {
            string queryStr = String.Format("SELECT [ID] FROM [Mail] WHERE [UIDL] = '{0}'", uidl);
            object[] values = { null };
            if (DBAccess.QuerySingleRecord(queryStr, ref values) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveEmailViaUIDL(string uidl)
        {
            string queryStr = String.Format("INSERT INTO [Mail] ([AccountID], [UIDL], [ReadFlag], [Folder]) VALUES({0}, '{1}', {2}, {3})",
                Session.AccountID, uidl, "Yes", 0);
            //byte[] emailStream = DownloadEmail(uidl);
            //OleDbParameter par = new OleDbParameter("@EmailData", emailStream);
            return DBAccess.ExecuteSQL(queryStr);
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
        }
    }
}
