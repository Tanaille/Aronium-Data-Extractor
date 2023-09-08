using System.Data.SQLite;

namespace AroniumDataExtractor.Services.DatabaseServices
{
    /// <summary>
    /// Contains SQLite database connect / disconnect methods.
    /// </summary>
    public class DatabaseService : IDatabaseService
    {
        public SQLiteConnection Connection { get; set; }

        public DatabaseService()
        {

        }

        /// <summary>
        /// Connect to a SQLite database.
        /// </summary>
        /// <param name="filePath">Path to the SQLite database.</param>
        public void Connect(string filePath)
        {
            SQLiteConnection connection = new SQLiteConnection($"DataSource={filePath}");
            Connection = connection;

            connection.Open();
        }

        /// <summary>
        /// Disconnect from a SQLite database.
        /// </summary>
        public void Disconnect()
        {
            Connection.Close();
        }
    }
}
