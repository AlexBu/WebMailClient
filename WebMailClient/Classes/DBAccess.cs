using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace WebMailClient
{
    public class DBAccess
    {
        static public bool ExecuteSQL(string ConnectionString, string SQLCommand)
        {
            OleDbConnection MdbConnection = null;
            OleDbCommand AccessCommand = null;
            int affectedRow = 0;
            try
            {
                MdbConnection = new OleDbConnection(ConnectionString);
                MdbConnection.Open();
                AccessCommand = new OleDbCommand(SQLCommand, MdbConnection);
                affectedRow = AccessCommand.ExecuteNonQuery();
            }
            catch (System.Exception)
            {

            }
            finally
            {
                MdbConnection.Close();
            }
            
            if(affectedRow != 0)
                return true;
            return false;
        }

        static public object QuerySingleItem(string ConnectionString, string SQLCommand)
        {
            OleDbConnection MdbConnection = null;
            OleDbCommand AccessCommand = null;
            object queryResult = -1;
            try
            {
                MdbConnection = new OleDbConnection(ConnectionString);
                MdbConnection.Open();
                AccessCommand = new OleDbCommand(SQLCommand, MdbConnection);
                queryResult = AccessCommand.ExecuteScalar();
            }
            catch (System.Exception)
            {

            }
            finally
            {
                MdbConnection.Close();
            }

            return queryResult;
        }

        static public void FillDataSet(string ConnectionString, string SQLCommand, ref DataSet dataset)
        {
            OleDbConnection MdbConnection = null;
            OleDbCommand AccessCommand = null;
            OleDbDataAdapter MdbDataAdapter = null;
            int addedRow = 0;
            try
            {
                MdbConnection = new OleDbConnection(ConnectionString);
                MdbConnection.Open();
                AccessCommand = new OleDbCommand(SQLCommand, MdbConnection);
                MdbDataAdapter = new OleDbDataAdapter(AccessCommand);
                addedRow = MdbDataAdapter.Fill(dataset);
            }
            catch (System.Exception)
            {

            }
            finally
            {
                MdbConnection.Close();
            }
        }
    }
}
