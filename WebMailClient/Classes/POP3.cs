using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace WebMailClient
{
    /// <summary>
    /// Pop3 的摘要说明。
    /// </summary>
    public class Pop3
    {
        private string mstrHost = null; //主机名称或IP地址
        private int mintPort = 110; //主机的端口号（默认为110）
        private TcpClient mtcpClient = null; //客户端
        private NetworkStream mnetStream = null; //网络基础数据流
        private StreamReader m_stmReader = null; //读取字节流
        private List<string> respondMsg = new List<string>();
        private List<string> mailList = new List<string>();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <remarks>一个邮件接收对象</remarks>
        public Pop3()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">主机名称或IP地址</param>
        public Pop3(string host)
        {
            mstrHost = host;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">主机名称或IP地址</param>
        /// <param name="port">主机的端口号</param>
        /// <remarks>一个邮件接收对象</remarks>
        public Pop3(string host, int port)
        {
            mstrHost = host;
            mintPort = port;
        }

        public string HostName
        {
            get { return mstrHost; }
            set { mstrHost = value; }
        }

        public int Port
        {
            get { return mintPort; }
            set { mintPort = value; }
        }

        /// <summary>
        /// 向网络访问的基础数据流中写数据（发送命令码）
        /// </summary>
        /// <param name="netStream">可以用于网络访问的基础数据流</param>
        /// <param name="command">命令行</param>
        /// <remarks>向网络访问的基础数据流中写数据（发送命令码）</remarks>
        private bool SendCmd(String command)
        {
            string strToSend = command + "\r\n";
            byte[] arrayToSend = Encoding.ASCII.GetBytes(strToSend);
            mnetStream.Write(arrayToSend, 0, arrayToSend.Length);

            return RecvStatus();
        }

        private bool RecvStatus()
        {
            respondMsg.Clear();
            respondMsg.Add(m_stmReader.ReadLine());

            if ( respondMsg[0].StartsWith("+OK") )
                return true;
            else
                return false;
        }

        private void RecvOneLineData()
        {
            respondMsg.Clear();
            respondMsg.Add(m_stmReader.ReadLine());
        }

        private void RecvMultiLineData()
        {
            string oneline = null;
            while (true)
            {
                oneline = m_stmReader.ReadLine();
                if (oneline == ".")
                    break;
                respondMsg.Add(oneline);
            }
        }

        private void SaveDataIntoStream(StreamWriter writer)
        {
            respondMsg.Clear();
            string oneline = null;
            while (true)
            {
                oneline = m_stmReader.ReadLine();
                if (oneline == ".")
                    break;
                writer.WriteLine(oneline);
            }
        }

        private bool SaveEmailInfo(string uidl, string from, string timestamp, string subject, int filesize)
        {
            string queryStr = String.Format(@"INSERT INTO [Mail] ([AccountID], [UIDL], [DeleteFlag], [From], [Date], [Subject], [Size]) 
                VALUES({0}, '{1}', {2}, '{3}', '{4}', '{5}', {6})",
                Session.AccountID, uidl, "No", from, timestamp, subject, filesize);
            return DBAccess.ExecuteSQL(queryStr);
        }

        #region Pop3Command

        private bool USER(string user)
        {
            return SendCmd("USER " + user);
        }

        private bool PASS(string password)
        {
            return SendCmd("PASS " + password);
        }

        private bool LIST()
        {
            if (SendCmd("LIST") == true)
            {
                RecvMultiLineData();
                return true;
            }
            return false;
        }

        private bool LIST(int index)
        {
            return SendCmd("LIST" + index.ToString());
        }

        private bool UIDL()
        {
            if (SendCmd("UIDL") == false)
                return false;
            RecvMultiLineData();
            mailList.Clear();
            respondMsg.RemoveAt(0);
            foreach (string str in respondMsg)
            {
                mailList.Add(str.Substring(str.IndexOf(' ') + 1));
            }
            return true;
        }

        private bool UIDL(int index)
        {
            return SendCmd("UIDL" + index.ToString());
        }

        private bool RETR(int number, StreamWriter writer)
        {
            if (SendCmd("RETR " + number.ToString()) == true)
            {
                SaveDataIntoStream(writer);
                return true;
            }
            return false;
        }

        private bool DELE(string uidl)
        {
            // effect after QUIT command
            // find the match index
            if (UIDL() == false)
                return false;
            int index = mailList.IndexOf(uidl);
            index++;
            if(index == 0)
                return false;
            return SendCmd("DELE " + index.ToString());
        }

        private bool QUIT()
        {
            return SendCmd("QUIT");
        }

        #endregion

        public bool Connect(string user, string password)
        {
            if (mstrHost == null)
                throw new Exception("请提供SMTP主机名称或IP地址！");
            if (mintPort == 0)
                throw new Exception("请提供SMTP主机的端口号");
            
            mtcpClient = new TcpClient(mstrHost, mintPort);
            mnetStream = mtcpClient.GetStream();
            m_stmReader = new StreamReader(mnetStream);

            if (RecvStatus() == true)
            {
                if (USER(user) == false)
                    throw new Exception("用户名不正确！");
                if (PASS(password) == false)
                    throw new Exception("用户口令不正确！");
                if (UIDL() == false)
                    throw new Exception("得到邮件列表时发生错误！");
                return true;
            }
            return false;
        }

        public void DisConnect()
        {
            QUIT();
            if (m_stmReader != null)
                m_stmReader.Close();
            if (mnetStream != null)
                mnetStream.Close();
            if (mtcpClient != null)
                mtcpClient.Close();
        }

        public void RetrieveEmail(DataTable locallist)
        {
            int downloadcount = 0;
            for ( int i = 0; i < mailList.Count; i++ )
            {
                bool found = false;
                string str = mailList[i];
                foreach (DataRow row in locallist.Rows)
                {
                    if (row["UIDL"].Equals(str))
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    downloadcount++;
                    if (downloadcount > Session.MaxEmailCount)
                        break;
                    // save email data to file
                    // app dir\mail\user\account\Inbox\mail list
                    string filepath = string.Format("{0}\\Mail\\{1}\\{2}\\Inbox\\",
                        Directory.GetCurrentDirectory(),
                        Session.LoginName,
                        Session.AccountName);
                    FileStream fs = null;
                    StreamWriter writer = null;
                    try
                    {

                        if (Directory.Exists(filepath) == false)
                        {
                            Directory.CreateDirectory(filepath);
                        }
                        fs = new FileStream(filepath + str, FileMode.Create, FileAccess.Write, FileShare.Read);
                        writer = new StreamWriter(fs);
                        // pop3 uidl index starts from 1 not 0
                        DownloadEmail(i + 1, writer);
                        writer.Flush();
                    }
                    catch (System.Exception)
                    {

                    }
                    finally
                    {
                        writer.Close();
                        fs.Close();
                    }

                    // parse email
                    EML eml = new EML();
                    if (eml.ParseEML(filepath + str) == true)
                        SaveEmailInfo(str, eml.From, eml.TimeStampRecv, eml.Subject, eml.Size);
                    eml.Close();
                }
            }
        }

        public bool DeleteMail(string uidl)
        {
            return DELE(uidl);
        }

        private void DownloadEmail(int index, StreamWriter writer)
        {
            // save email data into file
            RETR(index, writer);
        }
    }

}