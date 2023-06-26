using System.Data.SQLite;

namespace Lagosanto.Databases;

public class DatabaseBase
{
    private SQLiteConnection _connection;
    private const string USER_DB = "users.db";

    public DatabaseBase()
    { 
        _connection = new SQLiteConnection($"Data Source={USER_DB};Version=3;");
    }

    public SQLiteConnection GetConnection()
    {
        return _connection;
    }

    public string GetDB()
    {
        return USER_DB;
    }
}