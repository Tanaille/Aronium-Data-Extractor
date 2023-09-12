using System.Data.SQLite;

namespace AroniumDataExtractor.Services.DatabaseServices
{
    /// <summary>
    /// Contains SQLite database connect / disconnect methods.
    /// </summary>
    public class DatabaseService : IDatabaseService
    {
        public SQLiteConnection Connection { get; private set; }

        public DatabaseService()
        {
            SQLiteConnection connection = new SQLiteConnection();
            Connection = connection;
        }

        /// <summary>
        /// Connect to a SQLite database.
        /// </summary>
        /// <param name="filePath">Path to the SQLite database.</param>
        public void Connect(string filePath)
        {
            Connection.ParseViaFramework = true;
            Connection.ConnectionString = $"DataSource={filePath};Mode=ReadOnly";

            Connection.Open();
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
