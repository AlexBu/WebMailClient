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
        private static List<string> accountlist = new List<string>();

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

        public static List<string> AccountNames
        {
            get
            {
                return accountlist;
            }
            set
            {
                accountlist = value;
            }
        }
    }
}
