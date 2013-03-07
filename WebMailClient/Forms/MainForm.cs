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
            //throw new NotImplementedException();
        }

        private void LoadTreeView()
        {
            // add root node
            TreeNode newNode = new TreeNode("Text for new node");
            treeViewMailBox.Nodes.Add(newNode);
        }

        private void LoadEmailDB()
        {
            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
            string queryStr = null;
            // get account
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.AppendFormat("SELECT [Accountname] FROM [Account] WHERE [UserID] = {0}", Session.LoginID);
            queryStr = queryBuilder.ToString();
            string accountStr = (string)DBAccess.QuerySingleItem(connectionStr, queryStr);
            if(accountStr != null)
                Session.AccountNames.Add(accountStr);

            // get mail data
            queryStr = @"SELECT 
                [User.ID], [User.Username], [Account.ID], [Account.Accountname], 
                [Mail.ID], [Mail.UIDL], [Mail.ReadFlag], [Mail.Folder] 
                FROM [User], [Account], [Mail] 
                WHERE [User.ID] = [Account.UserID] AND [Account.ID] = [Mail.AccountID]";
            DBAccess.FillDataSet(connectionStr, queryStr, ref dataSetEmailLocal);
        }

        private void ContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show contact dialog
            Contact contact = new Contact();
            contact.ShowDialog();
        }
    }
}
