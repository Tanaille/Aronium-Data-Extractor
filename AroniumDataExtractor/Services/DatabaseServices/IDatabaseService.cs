using System.Data.SQLite;

namespace AroniumDataExtractor.Services.DatabaseServices
{
    public interface IDatabaseService
    {
        SQLiteConnection Connection { get; }

        void Connect(string filePath);
        void Disconnect();
    }
}