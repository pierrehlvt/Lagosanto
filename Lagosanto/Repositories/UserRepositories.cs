using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Windows.Forms;
using Lagosanto.Databases;
using Lagosanto.Models;
using Lagosanto.Repositories.Interfaces;
namespace Lagosanto.Repositories;

    public class UserRepository : DatabaseBase,IUserRepository
    {
        private SQLiteCommand _command;
        public UserRepository()
        {
            _command = new SQLiteCommand(GetConnection());
        }
        public void Add(User userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            if (GetConnection().State != ConnectionState.Open)
            {
                GetConnection().Open();
            }
            _command = GetConnection().CreateCommand();
            _command.CommandText = "SELECT COUNT(*) FROM [User] WHERE Username=@username AND Password=@password";
            _command.Parameters.AddWithValue("@username", credential.UserName);
            _command.Parameters.AddWithValue("@password", credential.Password);

            int result = Convert.ToInt32(_command.ExecuteScalar());
            validUser = result > 0;
            
            return validUser;
        }

        public void Edit(User userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            User user = new User();

            GetConnection().Open();
            _command.CommandText = "SELECT * FROM [User] WHERE username=@username";
            _command.Parameters.AddWithValue("@username", username);
            var reader = _command.ExecuteReader();

            if (reader.Read())
            {
                user = new User()
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = string.Empty,
                    Name = reader.GetString(3),
                    LastName = reader.GetString(4),
                    Role = reader.GetString(5)
                };
            }

            GetConnection().Close();
            return user;
        }

        public IEnumerable<User> GetByAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }