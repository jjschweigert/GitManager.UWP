using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;


namespace DataAccessLibrary
{
    public static class DataAccess
    {
        public static async void InitializeDatabase(string DatabasePath, string CreateTableCommand)
        {
            /*
             * CREATE TABLE IF NOT EXISTS <TABLE>
             * (Primary_Key INTEGER PRIMARY KEY,
             * <ColumnName> <DataType> <Default Value>,
             * ....
             * )
             *
             */
            using (SqliteConnection db = new SqliteConnection("Data Source="+ DatabasePath))
            {
                try
                {
                    db.Open();
                }
                catch(Exception ex)
                {
                    return;
                }

                //string tableCommand = "CREATE TABLE IF NOT EXISTS " + Table
                //                    + " (Primary_Key INTEGER PRIMARY KEY, "
                //                    + "StoreDir TEXT NOT NULL DEFAULT '')";

                SqliteCommand createTable = new SqliteCommand(CreateTableCommand, db);
                await createTable.ExecuteReaderAsync();

                db.Close();
            }
        }

        public static async void AddData(string DatabasePath, string AddDataCommand, Dictionary<string, string> Arguments)
        {
            using(SqliteConnection db = new SqliteConnection("Filename=" + DatabasePath))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand
                {
                    Connection = db,

                    // Use parameterized query to prevent SQL injection attacks
                    //CommandText = "INSERT INTO " + _Table + " VALUES " +
                    //                        "(NULL, @Path);"
                };

                insertCommand.CommandText = AddDataCommand;

                foreach(KeyValuePair<string, string> kvp in Arguments)
                {
                    insertCommand.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                }

                await insertCommand.ExecuteReaderAsync();

                db.Close();
            }
        }

        public static async Task<List<string>> GetData(string DatabasePath, string GetDataCommand, Dictionary<string, string> Arguments)
        {
            List<string> StoreDirs = new List<string>();

            using(SqliteConnection db = new SqliteConnection("Filename="+ DatabasePath))
            {
                db.Open();

                //string selectCommand = "SELECT StoreDir FROM " + _Table;
                //SqliteCommand selectRow = new SqliteCommand(selectCommand, db);
                SqliteCommand selectCommand = new SqliteCommand
                {
                    Connection = db
                };

                selectCommand.CommandText = GetDataCommand;

                foreach (KeyValuePair<string, string> kvp in Arguments)
                {
                    selectCommand.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                }

                SqliteDataReader query = await selectCommand.ExecuteReaderAsync();

                while(await query.ReadAsync())
                {
                    StoreDirs.Add(query.GetString(0));
                }

                db.Close();
            }

            return StoreDirs;
        }

        public static async Task<bool> DeleteData(string DatabasePath, string DeleteDataCommand, Dictionary<string, string> Arguments)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=" + DatabasePath))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand
                {
                    Connection = db
                };

                deleteCommand.CommandText = DeleteDataCommand;

                foreach (KeyValuePair<string, string> kvp in Arguments)
                {
                    deleteCommand.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                }

                await deleteCommand.ExecuteNonQueryAsync();

                db.Close();
            }

            return true;
        }
    }
}
