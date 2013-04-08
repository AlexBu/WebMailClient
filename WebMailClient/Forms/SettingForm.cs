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
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBoxUsername.Text = Session.AccountName;
            textBoxPassword.Text = Session.AccountPass;
            textBoxPOP3Server.Text = Session.Pop3Server;
            textBoxPOP3Port.Text = Session.Pop3Port.ToString();
            textBoxSMTPServer.Text = Session.SMTPServer;
            textBoxSMTPPort.Text = Session.SMTPPort.ToString();
            textBoxMaxEmailCount.Text = Session.MaxEmailCount.ToString();
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            textBoxPOP3Port.Text = "110";
            textBoxSMTPPort.Text = "25";
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSetting();
            DialogResult = DialogResult.OK;
        }

        private void SaveSetting()
        {
            // check if exist
            string queryStr = string.Format("SELECT * FROM [Account] WHERE [UserID] = {0}", Session.LoginID);
            if (DBAccess.QuerySingleItem(queryStr, 0) != null)
            {
                // update
                string updateStr = String.Format(@"UPDATE [Account] SET
                    [Accountname] = '{0}',
                    [Accountpass] = '{1}',
                    [POP3Server] = '{2}',
                    [POP3Port] = {3},
                    [SMTPServer] = '{4}',
                    [SMTPPort] = {5},
                    [MaxEmailCount] = {6}
                    WHERE [UserID] = {7}",
                    textBoxUsername.Text,
                    textBoxPassword.Text,
                    textBoxPOP3Server.Text,
                    textBoxPOP3Port.Text,
                    textBoxSMTPServer.Text,
                    textBoxSMTPPort.Text,
                    textBoxMaxEmailCount.Text,
                    Session.LoginID);
                DBAccess.ExecuteSQL(updateStr);
            }
            else
            {
                // insert
                string insertStr = String.Format(@"INSERT INTO [Account] 
                    ([UserID], [Accountname], [Accountpass], [POP3Server], [POP3Port], [SMTPServer], [SMTPPort], [MaxEmailCount]) 
                    VALUES ({0}, '{1}', '{2}', '{3}', {4}, '{5}', {6}, {7})",
                    Session.LoginID,
                    textBoxUsername.Text,
                    textBoxPassword.Text,
                    textBoxPOP3Server.Text,
                    textBoxPOP3Port.Text,
                    textBoxSMTPServer.Text,
                    textBoxSMTPPort.Text,
                    textBoxMaxEmailCount.Text
                    );
                DBAccess.ExecuteSQL(insertStr);
            }

        }

    }
}
