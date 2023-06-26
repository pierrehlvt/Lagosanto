using System.Data.SQLite;
using System.IO;

public class DatabaseHelper
{
    private const string USER_DB = "users.db";
    public DatabaseHelper()
    {
        bool isNewDatabase = !File.Exists(USER_DB);
        SQLiteConnection connection = new SQLiteConnection($"Data Source={USER_DB};Version=3;");

        if (isNewDatabase)
        {
            connection.Open();
            CreateTables(connection);
            InsertDefaultUser(connection);
            connection.Close();
        }
    }

    private void CreateTables(SQLiteConnection connection)
    {
        SQLiteCommand command = connection.CreateCommand();

        command.CommandText = @"
         CREATE TABLE IF NOT EXISTS [User] (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
              Username TEXT UNIQUE,
              Password TEXT,
              Name TEXT,
              LastName TEXT
         );
     ";
        command.ExecuteNonQuery();
    }
    
    private void InsertDefaultUser(SQLiteConnection connection)
    {
        SQLiteCommand command = connection.CreateCommand();
        command.CommandText = @"
         INSERT INTO [User] (Username, Password, Name, LastName)
          VALUES (@username, @password, @name, @lastName);
     ";
        command.Parameters.AddWithValue("@username", "admin");
        command.Parameters.AddWithValue("@password", "admin123");
        command.Parameters.AddWithValue("@name", "Admin");
        command.Parameters.AddWithValue("@lastName", "User");
        command.ExecuteNonQuery();
    }
    
}