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
        static private string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\webmaildb.mdb";
        static public bool ExecuteSQL(string SQLCommand)
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

        static public bool ExecuteSQL(string SQLCommand, OleDbParameter Parameter)
        {
            OleDbConnection MdbConnection = null;
            OleDbCommand AccessCommand = null;
            int affectedRow = 0;
            try
            {
                MdbConnection = new OleDbConnection(ConnectionString);
                MdbConnection.Open();
                AccessCommand = new OleDbCommand(SQLCommand, MdbConnection);
                AccessCommand.Parameters.Add(Parameter);
                affectedRow = AccessCommand.ExecuteNonQuery();
            }
            catch (System.Exception)
            {

            }
            finally
            {
                MdbConnection.Close();
            }

            if (affectedRow != 0)
                return true;
            return false;
        }

        static public object QuerySingleItem(string SQLCommand, int index)
        {
            OleDbConnection MdbConnection = null;
            OleDbCommand AccessCommand = null;
            OleDbDataReader DataReader = null;
            object queryResult = null;
            try
            {
                MdbConnection = new OleDbConnection(ConnectionString);
                MdbConnection.Open();
                AccessCommand = new OleDbCommand(SQLCommand, MdbConnection);
                DataReader = AccessCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (DataReader.Read() == true)
                    queryResult = DataReader.GetValue(index);
            }
            catch (System.Exception)
            {

            }
            finally
            {
                DataReader.Close();
                MdbConnection.Close();
            }

            return queryResult;
        }

        static public int QuerySingleRecord(string SQLCommand, ref object[] Values)
        {
            OleDbConnection MdbConnection = null;
            OleDbCommand AccessCommand = null;
            OleDbDataReader DataReader = null;
            int queryResult = 0;
            try
            {
                MdbConnection = new OleDbConnection(ConnectionString);
                MdbConnection.Open();
                AccessCommand = new OleDbCommand(SQLCommand, MdbConnection);
                DataReader = AccessCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (DataReader.Read() == true)
                    queryResult = DataReader.GetValues(Values);
                else
                    queryResult = 0;
            }
            catch (System.Exception)
            {

            }
            finally
            {
                DataReader.Close();
                MdbConnection.Close();
            }

            return queryResult;
        }

        static public void FillDataTable(string SQLCommand, ref DataTable dataset)
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
