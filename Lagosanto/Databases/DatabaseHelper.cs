using System.Data.SQLite;
using System.IO;
using Lagosanto.Databases;
using Lagosanto.Models;

public class DatabaseHelper: DatabaseBase
{
    public DatabaseHelper()
    {
        bool isNewDatabase = !File.Exists(GetDB());

        if (isNewDatabase)
        {
            GetConnection().Open();
            CreateTables();
            InsertUser("desk","1234","Jean","Didier",Role.ROLE_DESK);
            InsertUser("fabrication","1234","Jean","Dupont",Role.ROLE_FABRICATION);
            GetConnection().Close();
        }
    }

    private void CreateTables()
    {
        SQLiteCommand command = GetConnection().CreateCommand();

        command.CommandText = @"
         CREATE TABLE IF NOT EXISTS [User] (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
              Username TEXT UNIQUE,
              Password TEXT,
              Name TEXT,
              LastName TEXT,
              role TEXT
         );
     ";
        command.ExecuteNonQuery();
    }
    
    private void InsertUser(string username, string password, string name, string lastName, string role)
    {
        SQLiteCommand command = GetConnection().CreateCommand();
        command.CommandText = @"
        INSERT INTO [User] (Username, Password, Name, LastName, Role)
        VALUES (@username, @password, @name, @lastName, @role);
    ";
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@lastName", lastName);
        command.Parameters.AddWithValue("@role", role);
        command.ExecuteNonQuery();
    }
    
}