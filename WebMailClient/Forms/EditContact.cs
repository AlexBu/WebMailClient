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
    public partial class EditContact : Form
    {
        private string hiddenID;

        public EditContact()
        {
            InitializeComponent();
        }

        public string ID
        {
            get
            {
                return hiddenID;
            }
            set
            {
                hiddenID = value;
            }
        }
        public string EmailAddress
        {
            get
            {
                return textBoxAddress.Text;
            }
            set
            {
                textBoxAddress.Text = value;
            }
        }

        public string ContactName
        {
            get
            {
                return textBoxName.Text;
            }
            set
            {
                textBoxName.Text = value;
            }
        }

        public string Comment
        {
            get
            {
                return textBoxComment.Text;
            }
            set
            {
                textBoxComment.Text = value;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
