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

        private void OnLogin(object sender, EventArgs e)
        {
            // set login result
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnRegister(object sender, EventArgs e)
        {
            Register regForm = new Register();
            regForm.ShowDialog();
            if (regForm.DialogResult == DialogResult.OK)
            {
                // store register information
                string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
                string insertStr = null;
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("INSERT INTO User VALUES ('{0}', '{1}')", regForm.GetUsername(), regForm.GetPassword());
                insertStr = builder.ToString();
                DBAccess.CreateConnection(connectionStr, insertStr);
            }
        }

        private void OnReset(object sender, EventArgs e)
        {
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
