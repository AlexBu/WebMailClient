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
            string queryStr = String.Format("SELECT * FROM [User] WHERE [Username] = '{0}' AND [Password] = '{1}'", textBoxUserName.Text, MD5Crypt.getMd5Hash(textBoxPassword.Text));
            object[] values = { null };
            if(DBAccess.QuerySingleRecord(queryStr, ref values) == 1)
            {
                MessageBox.Show("登录成功!", "邮件系统");
                // set login result
                DialogResult = DialogResult.OK;
                // save session
                Session.LoginName = textBoxUserName.Text;
                Session.LoginID = (int)values[0];
                Close();
            }
            else
            {
                MessageBox.Show("登录失败!", "邮件系统");
                // save session
                Session.LoginName = "";
                Session.LoginID = -1;
                // reset input
                ResetInput();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register regForm = new Register();
            regForm.ShowDialog();
            if (regForm.DialogResult == DialogResult.OK)
            {
                // store register information
                string insertStr = String.Format("INSERT INTO [User] ([Username], [Password]) VALUES ('{0}', '{1}')", regForm.GetUsername(), regForm.GetPassword());
                if (DBAccess.ExecuteSQL(insertStr))
                {
                    MessageBox.Show("注册成功!", "邮件系统");
                }
                else
                {
                    MessageBox.Show("注册失败!", "邮件系统");
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void ResetInput()
        {
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
