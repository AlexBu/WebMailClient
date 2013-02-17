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

        private void Contact_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'webmaildbDataSet1.Contact' table. You can move, or remove it, as needed.
            this.contactTableAdapter1.Fill(this.webmaildbDataSet1.Contact);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
