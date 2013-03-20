using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace WebMailClient
{
    public partial class EditMail : Form
    {
        private MailMessage msg = null;
        private SmtpClient client = null;

        private List<string> attachList = new List<string>();

        public EditMail()
        {
            InitializeComponent();
        }

        public string Receiver
        {
            get
            {
                return textBoxReceive.Text;
            }
            set
            {
                textBoxReceive.Text = value;
            }
        }

        public string Subject
        {
            get
            {
                return textBoxTitle.Text;
            }
            set
            {
                textBoxTitle.Text = value;
            }
        }

        public MailMessage MSG
        {
            get
            {
                return msg;
            }
        }

        public SmtpClient Client
        {
            get
            {
                return client;
            }
        }

        public RichTextBox MailBody
        {
            get
            {
                return richTextBoxContent;
            }
        }

        private void buttonSendMail_Click(object sender, EventArgs e)
        {
            PrepareMail();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonAddAttachment_Click(object sender, EventArgs e)
        {
            AddAttachment();
        }

        private void buttonRemoveAttachment_Click(object sender, EventArgs e)
        {
            RemoveAttachment();
        }

        private void PrepareMail()
        {
            msg = new MailMessage();
            if (textBoxReceive.Text.Length == 0)
            {
                MessageBox.Show("收件地址不能为空!");
                return;
            }
            string[] addrlist = textBoxReceive.Text.Split(';');
            foreach (string str in addrlist)
            {
                if (str == "")
                    continue;
                msg.To.Add(str);
            }

            if (textBoxCC.Text.Length > 0)
            {
                addrlist = textBoxCC.Text.Split(';');
                foreach (string str in addrlist)
                {
                    if (str == "")
                        continue;
                    msg.CC.Add(str);
                }
            }
            if (textBoxBCC.Text.Length > 0)
            {
                addrlist = textBoxBCC.Text.Split(';');
                foreach (string str in addrlist)
                {
                    if (str == "")
                        continue;
                    msg.Bcc.Add(str);
                }
            }

            LoadAttachmentList();

            msg.From = new MailAddress(Session.AccountName, Session.AccountName, System.Text.Encoding.UTF8);
            msg.Subject = textBoxTitle.Text;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = richTextBoxContent.Text;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(Session.AccountName, Session.AccountPass);
            client.Host = Session.SMTPServer;
            client.Port = Session.SMTPPort;
            client.EnableSsl = false;
        }

        private void LoadAttachmentList()
        {
            foreach (string str in attachList)
            {
                Attachment attachment = new Attachment(str);
                msg.Attachments.Add(attachment);
            }
        }

        private void AddAttachment()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "添加附件";
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string newstr in dialog.FileNames)
                {
                    bool found = false;
                    foreach (string oldstr in attachList)
                    {
                        if (newstr == oldstr)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        // add to a tmp list
                        attachList.Add(newstr);
                    }
                }

                UpdateAttachmentList();
            }
        }

        private void UpdateAttachmentList()
        {
            listBoxAttachment.Items.Clear();
            foreach (string str in attachList)
            {
                listBoxAttachment.Items.Add(str);
            }
        }

        private void RemoveAttachment()
        {
            // remove all the selected attachment
            for (int i = listBoxAttachment.Items.Count - 1; i >= 0; i--)
            {
                if (listBoxAttachment.GetSelected(i) == true)
                {
                    listBoxAttachment.Items.RemoveAt(i);
                    attachList.RemoveAt(i);
                }
            }
        }
    }
}
