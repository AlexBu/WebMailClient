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
        private DataTable datatableInbox;
        //private DataTable datatableOutbox;
        //private DataTable datatableDraft;
        //private DataTable datatableRecycle;
        //private DataTable datatableSentbox;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // load email database
            LoadEmailDB();
            // load tree view
            LoadTreeView();
            // receive email from web
            DownloadEmailData();
        }

        private void DownloadEmailData()
        {
            // download email data and fill into database
            Pop3 mailbox = new Pop3("pop3.163.com");
            mailbox.Connect();
            mailbox.RetrieveEmail(Session.AccountName, Session.AccountPass);
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
        }

        private void LoadEmailDB()
        {
            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
            string queryStr = String.Format("SELECT [ID], [Accountname], [Accountpass] FROM [Account] WHERE [UserID] = {0}", Session.LoginID);
            // get account
            object[] values = {null, null, null};
            if (DBAccess.QuerySingleRecord(connectionStr, queryStr, ref values) == 3)
            {
                Session.AccountID = (int)values[0];
                Session.AccountName = (string)values[1];
                Session.AccountPass = (string)values[2];
            }

            if (Session.AccountName == null)
                return;

            // get mail data
            queryStr = String.Format(@"SELECT [Mail.ID], [Mail.UIDL], [Mail.ReadFlag], [Mail.Folder] 
                FROM [Mail] WHERE [Mail.AccountID] = {0}", Session.AccountID);
            //DBAccess.FillDataTable(connectionStr, queryStr, ref dataSetEmailLocal);

            // load into different datatable
            //LoadInboxDB();
            //LoadOutboxDB();
            //LoadDraftDB();
            //LoadRecycleDB();
            //LoadSentboxDB();
        }

        private void LoadSentboxDB()
        {
            //throw new NotImplementedException();
        }

        private void LoadRecycleDB()
        {
            //throw new NotImplementedException();
        }

        private void LoadDraftDB()
        {
            //throw new NotImplementedException();
        }

        private void LoadOutboxDB()
        {
            //throw new NotImplementedException();
        }

        private void LoadInboxDB()
        {
            datatableInbox = new DataTable();
//            queryStr = String.Format(@"SELECT [Mail.ID], [Mail.UIDL], [Mail.ReadFlag], [Mail.Folder] 
//                FROM [Mail] WHERE [Mail.AccountID] = {0}", Session.AccountID);
//            DBAccess.FillDataTable(connectionStr, queryStr, ref dataSetEmailLocal);
        }

        private void ContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show contact dialog
            Contact contact = new Contact();
            contact.ShowDialog();
        }
    }
}
