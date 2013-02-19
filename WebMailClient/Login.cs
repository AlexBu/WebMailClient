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
            }
        }

        private void OnReset(object sender, EventArgs e)
        {
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
