using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace WebMailClient
{
    class MailBox
    {
        static public void CleanRootFolder()
        {
            // delete all folders and files under the mail folder of the account
            string rootpath = Utility.GetRootPath();
            if (Directory.Exists(rootpath) == true)
            {
                Directory.Delete(rootpath, true);
            }
        }

        static public void CleanDataInDB()
        {
            // clear all the record inside database of this account
            // delete record
            string deleteStr = string.Format("DELETE FROM [Mail] WHERE [AccountID] = {0}", Session.AccountID);

            DBAccess.ExecuteSQL(deleteStr);
        }
    }
}
