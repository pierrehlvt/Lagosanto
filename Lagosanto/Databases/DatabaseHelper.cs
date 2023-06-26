using System.Data.SQLite;
using System.IO;
using Lagosanto.Databases;
using Lagosanto.Models;

public class DatabaseHelper: DatabaseBase
{
    public DatabaseHelper()
    {
        bool isNewDatabase = !File.Exists(GetDbName());

        if (isNewDatabase)
        {
            GetConnection().Open();
            CreateTables();
            
            User desk = new User();
            desk.Username = "desk";
            desk.Password = "1234";
            desk.LastName = "Didier";
            desk.Name = "Jean";
            desk.Role = Role.ROLE_DESK;
            
            User fabrication = new User();
            fabrication.Username = "fabrication";
            desk.Password = "1234";
            desk.LastName = "Dupont";
            desk.Name = "Pierre";
            desk.Role = Role.ROLE_FABRICATION;
            
            InsertUser(desk);
            InsertUser(fabrication);
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
         );";
        
        command.ExecuteNonQuery();
    }
    
    private void InsertUser(User user)
    {
        SQLiteCommand command = GetConnection().CreateCommand();
        command.CommandText = @"
        INSERT INTO [User] (Username, Password, Name, LastName, Role)
        VALUES (@username, @password, @name, @lastName, @role);
    ";
        command.Parameters.AddWithValue("@username", user.Username);
        command.Parameters.AddWithValue("@password", user.Password);
        command.Parameters.AddWithValue("@name", user.Name);
        command.Parameters.AddWithValue("@lastName", user.LastName);
        command.Parameters.AddWithValue("@role", user.Role);
        command.ExecuteNonQuery();
    }
    
}