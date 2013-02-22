using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WebMailClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login loginForm = new Login();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
            
        }
    }
}
