using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WebMailClient
{
    public class Utility
    {
        // app dir\mail\user\account\Inbox\mail-list
        static public string GetInboxBoxPath()
        {
            if (Session.AccountName == null || Session.AccountName == "")
                return "";
            string filepath = string.Format("{0}\\Mail\\{1}\\{2}\\Inbox\\",
                Directory.GetCurrentDirectory(),
                Session.LoginName,
                Session.AccountName);
            if (Directory.Exists(filepath) == false)
            {
                Directory.CreateDirectory(filepath);
            }

            return filepath;
        }

        static public string GetSentBoxPath()
        {
            if (Session.AccountName == null || Session.AccountName == "")
                return "";
            string filepath = string.Format("{0}\\Mail\\{1}\\{2}\\Sent\\",
                Directory.GetCurrentDirectory(),
                Session.LoginName,
                Session.AccountName);
            if (Directory.Exists(filepath) == false)
            {
                Directory.CreateDirectory(filepath);
            }

            return filepath;
        }

        static public string GetDraftPath()
        {
            if (Session.AccountName == null || Session.AccountName == "")
                return "";
            string filepath = string.Format("{0}\\Mail\\{1}\\{2}\\Draft\\",
                Directory.GetCurrentDirectory(),
                Session.LoginName,
                Session.AccountName);
            if (Directory.Exists(filepath) == false)
            {
                Directory.CreateDirectory(filepath);
            }

            return filepath;
        }

        static public string GetOutBoxPath()
        {
            if (Session.AccountName == null || Session.AccountName == "")
                return "";
            string filepath = string.Format("{0}\\Mail\\{1}\\{2}\\Outbox\\",
                Directory.GetCurrentDirectory(),
                Session.LoginName,
                Session.AccountName);
            if (Directory.Exists(filepath) == false)
            {
                Directory.CreateDirectory(filepath);
            }

            return filepath;
        }
    }
}
