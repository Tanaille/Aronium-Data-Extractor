using System.Data.SQLite;

namespace AroniumDataExtractor.Services.DatabaseServices
{
    public class DatabaseService : IDatabaseService
    {
        public SQLiteConnection Connection { get; set; }

        public DatabaseService()
        {
        }

        public async void Connect(string filePath)
        {
            SQLiteConnection connection = new SQLiteConnection($"DataSource={filePath}");
            Connection = connection;

            await connection.OpenAsync();
        }

        public async void Disconnect()
        {
            await Connection.CloseAsync();
        }
    }
}
