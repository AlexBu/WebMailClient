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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public string GetUsername()
        {
            return textBoxUserName.Text;
        }

        public string GetPassword()
        {
            return MD5Crypt.getMd5Hash(textBoxPassword.Text);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if(textBoxPassword.Text != textBoxReEnterPassword.Text)
            {
                MessageBox.Show("密码不一致!", "Webmail", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
            textBoxReEnterPassword.Text = "";
        }
    }
}
