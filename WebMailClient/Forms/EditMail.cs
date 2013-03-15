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
        public EditMail()
        {
            InitializeComponent();
        }

        public string Sender
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

        private void buttonSendMail_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            if (textBoxReceive.Text.Length == 0)
            {
                MessageBox.Show("收件地址不能为空!");
                return;
            }
            string[] addrlist = textBoxReceive.Text.Split(';');
            foreach (string str in addrlist)
            {
                msg.To.Add(str);
            }

            if (textBoxCC.Text.Length > 0)
            {
                addrlist = textBoxCC.Text.Split(';');
                foreach (string str in addrlist)
                {
                    msg.CC.Add(str);
                }
            }
            if (textBoxBCC.Text.Length > 0)
            {
                addrlist = textBoxBCC.Text.Split(';');
                foreach (string str in addrlist)
                {
                    msg.Bcc.Add(str);
                }
            }
            if (textBoxAttachment.Text.Length > 0)
            {
                addrlist = textBoxAttachment.Text.Split(';');
                foreach (string str in addrlist)
                {
                    if(str == "")
                        continue;
                    Attachment attachment = new Attachment(str);
                    msg.Attachments.Add(attachment);
                }
            }
            msg.From = new MailAddress(Session.AccountName, Session.AccountName, System.Text.Encoding.UTF8);
            msg.Subject = textBoxTitle.Text;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = richTextBoxContent.Text;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(Session.AccountName, Session.AccountPass);
            client.Host = "smtp.163.com";
            client.EnableSsl = false;
            try
            {
                client.Send(msg);
                MessageBox.Show("发送成功");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(ex.Message, "发送邮件出错");
            }
        }

        private void buttonAddAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "添加附件";
            dialog.Filter = "All files (*.*)|*.*";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] oldAttatchList = textBoxAttachment.Text.Split(';');
                List<string> tmplist = new List<string>();
                foreach (string str in oldAttatchList)
                {
                    tmplist.Add(str);
                }

                foreach (string newstr in dialog.FileNames)
                {
                    bool found = false;
                    foreach (string oldstr in oldAttatchList)
                    {
                        if(newstr == oldstr)
                        {
                            found = true;
                            break;
                        }
                    }
                    if(found == false)
                    {
                        // add to a tmp list
                        tmplist.Add(newstr);
                    }
                }

                textBoxAttachment.Text = "";
                foreach (string str in tmplist)
                {
                    if(str == "")
                        continue;
                    textBoxAttachment.Text += str + ';';
                }
            }
        }
    }
}
