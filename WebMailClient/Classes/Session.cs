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
    }
}
