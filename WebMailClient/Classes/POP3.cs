﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
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
        private List<string> respondMsg = new List<string>(); //执行STAT命令后得到的消息（从中得到邮件数）
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

        #region Properties

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
        #endregion


        /// <summary>
        /// 向网络访问的基础数据流中写数据（发送命令码）
        /// </summary>
        /// <param name="netStream">可以用于网络访问的基础数据流</param>
        /// <param name="command">命令行</param>
        /// <remarks>向网络访问的基础数据流中写数据（发送命令码）</remarks>
        private void SendCmd(ref NetworkStream netStream, String command)
        {
            try
            {
                string strToSend = command + "\r\n";
                byte[] arrayToSend = Encoding.ASCII.GetBytes(strToSend/*.ToCharArray()*/);
                netStream.Write(arrayToSend, 0, arrayToSend.Length);
            }
            catch (Exception)
            {
            	
            }
        }

        private int GetMailNumber(string message)
        {
            string[] strMessage = message.Split(' ');
            return Int32.Parse(strMessage[1]);
        }

        private string GetDecodeMailContent(List<string> encodingContent)
        {
            // need implementation
            return null;
        }

        private bool ExecuteCommand(string command, int mode)
        {
            SendCmd(ref mnetStream, command);

            respondMsg.Clear();
            string oneline = null;
            while (true)
            {
                oneline = m_stmReader.ReadLine();
                if(oneline == ".")
                    break;
                respondMsg.Add(oneline);
                if(mode == 0)
                    break;
            }

            //判断执行结果是否正确
            return respondMsg[0].StartsWith("+OK");
        }

        #region Pop3Command

        private bool USER(string user)
        {
            return ExecuteCommand("USER " + user, 0);
        }

        private bool PASS(string password)
        {
            return ExecuteCommand("PASS " + password, 0);
        }

        private bool LIST()
        {
            return ExecuteCommand("LIST", 1);
        }

        private bool UIDL()
        {
            bool result = false;
            result = ExecuteCommand("UIDL", 1);
            if (result == false)
                return result;
            mailList.Clear();
            foreach (string str in respondMsg)
            {
                mailList.Add(str.Substring(str.IndexOf(' ') + 1));
            }
            mailList.RemoveAt(0);
            return true;
        }

        private bool NOOP()
        {
            return ExecuteCommand("NOOP", 0);
        }

        private bool STAT()
        {
            return ExecuteCommand("STAT", 0);
        }

        private bool RETR(int number)
        {
            return ExecuteCommand("RETR " + number.ToString(), 1);
        }

        private bool RETR(string uidl)
        {
            return ExecuteCommand("RETR " + uidl, 1);
        }

        private bool DELE(int number)
        {
            return ExecuteCommand("DELE " + number.ToString(), 0);
        }

        private void Quit()
        {
            ExecuteCommand("STAT", 0);
        }

        #endregion

        public bool Connect()
        {
            if (mstrHost == null)
                throw new Exception("请提供SMTP主机名称或IP地址！");

            if (mintPort == 0)
                throw new Exception("请提供SMTP主机的端口号");

            try
            {
                mtcpClient = new TcpClient(mstrHost, mintPort);
                mnetStream = mtcpClient.GetStream();
                m_stmReader = new StreamReader(mnetStream);
                string strMessage = m_stmReader.ReadLine();
                return strMessage.StartsWith("+OK");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DisConnect()
        {
            try
            {
                Quit();
                if (m_stmReader != null)
                    m_stmReader.Close();
                if (mnetStream != null)
                    mnetStream.Close();
                if (mtcpClient != null)
                    mtcpClient.Close();
            }

            catch (Exception exc)
            {
                throw new Exception(exc.ToString());
            }
        }

        public string[] RetrieveEmail(string user, string password)
        {
            try
            {
                if (USER(user) == false)
                    throw new Exception("用户名不正确！");
                if (PASS(password) == false)
                    throw new Exception("用户口令不正确！");
                if (STAT() == false)
                    throw new Exception("准备接收邮件时发生错误！");
                if (UIDL() == false)
                    throw new Exception("得到邮件列表时发生错误！");
                GetNewMail();
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void GetNewMail()
        {
            foreach (string str in mailList)
            {
                if (IsEmailDownloaded(str) == false)
                    SaveEmailViaUIDL(str);
            }
        }

        /// <summary>

        /// 删除邮件

        /// </summary>

        /// <param name="number">邮件号</param>

        public void DeleteMail(int number)

        {

            //删除邮件

            int iMailNumber = number + 1;

            if (DELE(iMailNumber).Equals("Error"))

                throw new Exception("删除第" + iMailNumber.ToString() + "时出现错误！");

        }

        public bool IsEmailDownloaded(string uidl)
        {
            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
            string queryStr = String.Format("SELECT [ID] FROM [Mail] WHERE [UIDL] = '{0}'", uidl);
            object[] values = { null };
            if (DBAccess.QuerySingleRecord(connectionStr, queryStr, ref values) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveEmailViaUIDL(string uidl)
        {
            string connectionStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
            string queryStr = String.Format("INSERT INTO [Mail] ([AccountID], [UIDL], [ReadFlag], [Content], [Folder]) VALUES({0}, '{1}', {2}, @EmailData, {3})",
                Session.AccountID, uidl, "Yes", 0);
            byte[] emailStream = DownloadEmail(uidl);
            OleDbParameter par = new OleDbParameter("@EmailData", emailStream);
            return DBAccess.ExecuteSQL(connectionStr, queryStr, par);
        }

        private byte[] DownloadEmail(string uidl)
        {
            RETR(uidl);
            string oneline = null;
            respondMsg.RemoveAt(0);
            foreach (string str in respondMsg)
            {
                oneline += str + "\r\n";
            }
            return Encoding.ASCII.GetBytes(oneline);
        }
    }

}