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
            // load  contact data
            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
            string queryStr = "SELECT * FROM [Contact]";
            DBAccess.FillDataSet(connectionStr, queryStr, ref dataSetContact);
        }
    }
}
