using System.Data.SQLite;

namespace Lagosanto.Repositories;

public class RepositoryBase
{
    private SQLiteConnection _connection;
    private const string USER_DB = "users.db";

    public RepositoryBase()
    { 
        _connection = new SQLiteConnection($"Data Source={USER_DB};Version=3;");
    }

    public SQLiteConnection GetConnection()
    {
        return _connection;
    }
}