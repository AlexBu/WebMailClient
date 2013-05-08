﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WebMailClient
{
    public partial class ViewMail : Form
    {
        public ViewMail()
        {
            InitializeComponent();
        }

        private string filename = "";
        private EML eml = null;
        private string to = "";
        private string title = "";

        public string ID
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }

        public string To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        private void ViewMail_Load(object sender, EventArgs e)
        {
            // load email content from file, file name: uidl
            if (filename == "")
            {
                return;
            }

            eml = new EML();
            if (eml.ParseEML(filename) == false)
            {
                eml.Close();
                return;
            }

            textBoxFrom.Text = eml.From;
            textBoxCC.Text = eml.CC;
            textBoxBCC.Text = eml.BCC;
            textBoxTitle.Text = eml.Subject;
            textBoxTime.Text = eml.TimeStampRecv;

            if (eml.HTMLBody != "")
            {
                webBrowserContent.DocumentText = eml.HTMLBody;
            }
            else
            {
                webBrowserContent.DocumentText = eml.TextBody;
            }

            if (eml.AttachCount == 0)
                listBoxAttachment.Enabled = false;
            else
                listBoxAttachment.Enabled = true;
            // load attachment
            for (int i = 0; i < eml.AttachCount; i++)
            {
                listBoxAttachment.Items.Add(eml.GetAttachmentName(i));
            }

            eml.Close();
        }

        private void listBoxAttachment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // save file
            if (eml == null)
                return;
            int index = listBoxAttachment.IndexFromPoint(e.Location);
            if (index == ListBox.NoMatches)
                return;

            string filename = eml.GetAttachmentName(index);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Title = "保存附件";
            dialog.FileName = filename;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                eml.SaveAttachment(index, dialog.FileName);
            }
        }

        private void buttonReplyMail_Click(object sender, EventArgs e)
        {
            to = textBoxFrom.Text;
            title = textBoxTitle.Text;

            DialogResult = DialogResult.OK;

            Close();
        }


        public string GetContent()
        {
            return webBrowserContent.DocumentText;
        }
    }
}
