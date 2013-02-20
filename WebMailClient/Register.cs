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
            return textBoxPassword.Text;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
