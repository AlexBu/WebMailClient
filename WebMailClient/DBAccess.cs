using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace WebMailClient
{
    public class DBAccess
    {
        static public bool CreateConnection(string ConnectionString, string SQLCommand)
        {
            OleDbConnection MdbConnection = null;
            OleDbCommand AccessCommand = null;
            int affectedRow = 0;
            try
            {
                MdbConnection = new OleDbConnection(ConnectionString);
                AccessCommand = new OleDbCommand(SQLCommand, MdbConnection);
                MdbConnection.Open();
                affectedRow = AccessCommand.ExecuteNonQuery();
            }
            catch (System.Exception)
            {

            }
            finally
            {
                MdbConnection.Close();
            }
            
            return true;
        }

        static int Insert()
        {
            return 0;
        }
    }
}
