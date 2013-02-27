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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
            string queryStr = null;
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("SELECT * FROM [User] WHERE [Username] = '{0}' AND [Password] = '{1}'", textBoxUserName.Text, MD5Crypt.getMd5Hash(textBoxPassword.Text));
            queryStr = builder.ToString();
            if (DBAccess.QuerySingleRow(connectionStr, queryStr))
            {
                MessageBox.Show("登录成功!", "Webmail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                // set login result
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("登录失败!", "Webmail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register regForm = new Register();
            regForm.ShowDialog();
            if (regForm.DialogResult == DialogResult.OK)
            {
                // store register information
                string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
                string insertStr = null;
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("INSERT INTO [User] ([Username], [Password]) VALUES ('{0}', '{1}')", regForm.GetUsername(), regForm.GetPassword());
                insertStr = builder.ToString();
                if (DBAccess.ExecuteSQL(connectionStr, insertStr))
                {
                    MessageBox.Show("注册成功!", "Webmail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("注册失败!", "Webmail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
