using System.Data.SQLite;

namespace AroniumDataExtractor.Services.DatabaseServices
{
    public interface IDatabaseService
    {
        SQLiteConnection Connection { get; set; }

        void Connect(string filePath);
    }
}