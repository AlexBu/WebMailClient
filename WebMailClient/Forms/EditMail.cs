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

        private void buttonSendMail_Click(object sender, EventArgs e)
        {
            MailMessage msg = new MailMessage();
            if (textBoxReceive.Text.Length == 0)
            {
                MessageBox.Show("收件地址不能为空!");
                return;
            }
            msg.To.Add(textBoxReceive.Text);
            if (textBoxCC.Text.Length > 0)
                msg.CC.Add(textBoxCC.Text);
            if (textBoxBCC.Text.Length > 0)
                msg.Bcc.Add(textBoxBCC.Text);
            msg.From = new MailAddress("bspbsp000@163.com", "AlexBu", System.Text.Encoding.UTF8);
            msg.Subject = textBoxTitle.Text;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = richTextBoxContent.Text;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("bspbsp000@163.com", "bsp2236");
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
    }
}
