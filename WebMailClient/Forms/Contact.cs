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
    public partial class Contact : Form
    {
        public Contact()
        {
            InitializeComponent();
        }

        private string receiverlist;

        public string TO
        {
            get
            {
                return receiverlist;
            }
        }

        private void Contact_Load(object sender, EventArgs e)
        {
            LoadContact();
        }

        private void LoadContact()
        {
            dataSetContact.Clear();
            // load  contact data
            string queryStr = "SELECT * FROM [Contact]";
            DataTable datatable = new DataTable();
            dataSetContact.Tables.Add(datatable);
            DBAccess.FillDataTable(queryStr, ref datatable);

            dataGridViewContact.AutoGenerateColumns = true;
            dataGridViewContact.DataSource = datatable;//dataSetContact.Tables[0];
            dataGridViewContact.AutoResizeColumns();
            // hide the first column
            dataGridViewContact.Columns[0].Visible = false;
            dataGridViewContact.Columns[1].HeaderText = "邮件地址";
            dataGridViewContact.Columns[2].HeaderText = "姓名";
            dataGridViewContact.Columns[3].HeaderText = "备注";
        }

        private void EditContact(int row)
        {
            // edit record
            EditContact editContact = new EditContact();
            editContact.ID = dataGridViewContact.Rows[row].Cells[0].Value.ToString();
            editContact.EmailAddress = dataGridViewContact.Rows[row].Cells[1].Value.ToString();
            editContact.ContactName = dataGridViewContact.Rows[row].Cells[2].Value.ToString();
            editContact.Comment = dataGridViewContact.Rows[row].Cells[3].Value.ToString();
            editContact.ShowDialog();
            if (editContact.DialogResult == DialogResult.OK)
            {
                // add record
                string updateStr = String.Format("UPDATE [Contact] SET [Email Address] = '{0}', [Name] = '{1}', [comment] = '{2}' WHERE [ID] = {3}",
                    editContact.EmailAddress, editContact.ContactName, editContact.Comment, editContact.ID);
                if (DBAccess.ExecuteSQL(updateStr))
                {
                    MessageBox.Show("更新联系人成功!", "邮件系统");
                }
                else
                {
                    MessageBox.Show("更新联系人失败!", "邮件系统");
                }

                LoadContact();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EditContact editContact = new EditContact();
            editContact.ShowDialog();
            if (editContact.DialogResult == DialogResult.OK)
            {
                // add record
                string insertStr = String.Format("INSERT INTO [Contact] ([Email Address], [Name], [comment]) VALUES ('{0}', '{1}', '{2}')", 
                    editContact.EmailAddress, editContact.ContactName, editContact.Comment);
                if (DBAccess.ExecuteSQL(insertStr))
                {
                    MessageBox.Show("添加联系人成功!", "邮件系统");
                }
                else
                {
                    MessageBox.Show("添加联系人失败!", "邮件系统");
                }

                LoadContact();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // delete record
            string insertStr = null;
            StringBuilder builder = new StringBuilder();
            // need to process multi rows
            builder.AppendFormat("DELETE FROM [Contact] WHERE ");
            foreach (DataGridViewRow row in dataGridViewContact.SelectedRows)
            {
                builder.AppendFormat("[ID] = {0} OR ", row.Cells[0].Value.ToString());
            }
            builder.AppendFormat("0");  // meaningless

            insertStr = builder.ToString();
            if (DBAccess.ExecuteSQL(insertStr))
            {
                MessageBox.Show("删除联系人成功!", "邮件系统");
            }
            else
            {
                MessageBox.Show("删除联系人失败!", "邮件系统");
            }

            LoadContact();
        }

        private void dataGridViewContact_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            EditContact(e.RowIndex);
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SetReceiverName();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SetReceiverName()
        {
            receiverlist = null;
            foreach (DataGridViewRow row in dataGridViewContact.SelectedRows)
            {
                receiverlist += row.Cells[1].Value.ToString() + ';';
            }
        }
    }
}
