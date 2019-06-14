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
        private static string _Filename { get; set; }
        private static string _Table { get; set; }

        /// <summary>
        /// Initializes a database located in a file given by Filename if not exists. Then a table called Table is created under the database if not exists.
        /// </summary>
        /// <param name="Filename">The filename to store the database in.</param>
        /// <param name="Table">The name of the table to create in the database</param>
        public static async void InitializeDatabase(string Filename, string Table)
        {
            _Filename = Filename;
            _Table = Table;

            using (SqliteConnection db = new SqliteConnection("Data Source="+_Filename+".db"))
            {
                /*
                 * Table
                 *
                 * Store Directory - text
                 *
                 */
                try
                {
                    db.Open();
                }
                catch(Exception ex)
                {
                    return;
                }

                string tableCommand = "CREATE TABLE IF NOT EXISTS " + _Table
                                    + " (Primary_Key INTEGER PRIMARY KEY, "
                                    + "StoreDir TEXT NOT NULL DEFAULT '')";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                await createTable.ExecuteReaderAsync();

                db.Close();
            }
        }

        public static async void AddData(string StoreDir)
        {
            using(SqliteConnection db = new SqliteConnection("Filename="+_Filename+".db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand
                {
                    Connection = db,

                    // Use parameterized query to prevent SQL injection attacks
                    CommandText = "INSERT INTO " + _Table + " VALUES " +
                                            "(NULL, @Path);"
                };
                insertCommand.Parameters.AddWithValue("@Path", StoreDir);

                await insertCommand.ExecuteReaderAsync();

                db.Close();
            }
        }

        public static async Task<List<string>> GetStores()
        {
            List<string> StoreDirs = new List<string>();

            using(SqliteConnection db = new SqliteConnection("Filename="+_Filename+".db"))
            {
                db.Open();

                string selectCommand = "SELECT StoreDir FROM " + _Table;
                SqliteCommand selectRow = new SqliteCommand(selectCommand, db);

                SqliteDataReader query = await selectRow.ExecuteReaderAsync();

                while(await query.ReadAsync())
                {
                    StoreDirs.Add(query.GetString(0));
                }

                db.Close();
            }

            return StoreDirs;
        }

        public static async Task<bool> DeleteStores(List<string> Stores)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=" + _Filename + ".db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand
                {
                    Connection = db
                };

                if (Stores != null && Stores.Count > 0)
                {
                    foreach (string store in Stores)
                    {
                        insertCommand.CommandText = "DELETE FROM " + _Table + " WHERE StoreDir = @dir";
                        insertCommand.Parameters.AddWithValue("@dir", store);
                        await insertCommand.ExecuteNonQueryAsync();
                    }
                }
                else
                {
                    insertCommand.CommandText = "DELETE FROM " + _Table + ";";
                    await insertCommand.ExecuteNonQueryAsync();
                }

                db.Close();
            }

            return true;
        }
    }
}
