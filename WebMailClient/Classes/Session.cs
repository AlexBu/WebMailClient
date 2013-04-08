using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebMailClient
{
    public static class Session
    {
        private static string username;
        private static int userid;
        private static int accountid;
        private static string accountname;
        private static string accountpass;
        private static string pop3server;
        private static int pop3port;
        private static string smtpserver;
        private static int smtpport;
        private static int maxemailcount;

        public static string LoginName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public static int LoginID
        {
            get
            {
                return userid;
            }
            set
            {
                userid = value;
            }
        }

        public static int AccountID
        {
            get
            {
                return accountid;
            }
            set
            {
                accountid = value;
            }
        }

        public static string AccountName
        {
            get
            {
                return accountname;
            }
            set
            {
                accountname = value;
            }
        }

        public static string AccountPass
        {
            get
            {
                return accountpass;
            }
            set
            {
                accountpass = value;
            }
        }

        public static string Pop3Server
        {
            get
            {
                return pop3server;
            }
            set
            {
                pop3server = value;
            }
        }

        public static int Pop3Port
        {
            get
            {
                return pop3port;
            }
            set
            {
                pop3port = value;
            }
        }

        public static string SMTPServer
        {
            get
            {
                return smtpserver;
            }
            set
            {
                smtpserver = value;
            }
        }

        public static int SMTPPort
        {
            get
            {
                return smtpport;
            }
            set
            {
                smtpport = value;
            }
        }

        public static int MaxEmailCount
        {
            get
            {
                return maxemailcount;
            }
            set
            {
                maxemailcount = value;
            }
        }

        public static bool SettingIsValid()
        {
            if (username == "")
                return false;
            if (userid <= 0)
                return false;
            if (accountid <= 0)
                return false;
            if (accountname == "")
                return false;
            if (accountpass == "")
                return false;
            if (pop3server == "")
                return false;
            if (pop3port <= 0)
                return false;
            if (smtpserver == "")
                return false;
            if (smtpport <= 0)
                return false;
            return true;
        }
    }
}
