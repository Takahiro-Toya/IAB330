using System;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using SnackRoulette.Models;
using System.Collections.Generic;

namespace SnackRoulette.Database
{
    public class UserDatabaseHelper
    {
        private SQLiteConnection SQLite_Connection;
        public UserDatabaseHelper()
        {
            SQLite_Connection = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            SQLite_Connection.CreateTable<UserModel>();
        }

        public string AddUser(UserModel user)
        {
            var data = SQLite_Connection.Table<UserModel>();
            var newData = data.Where(i => i.userName == user.userName && i.email == user.email).FirstOrDefault();
            if (newData == null)
            {
                SQLite_Connection.Insert(user);
                return "Successful";
            }
            else
            {
                return "That Email Address is Taken";
            }
                
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return (from users in SQLite_Connection.Table<UserModel>()
                    select users).ToList();
        }

        public UserModel GetUser(string email)
        {
            return SQLite_Connection.Table<UserModel>().FirstOrDefault(user => user.email == email);
        }

        public bool LoginValidation (string _email, string _password)
        {
            var data = SQLite_Connection.Table<UserModel>();
            var newData = data.Where(user => user.email == _email && user.password == _password).FirstOrDefault();
            if (newData != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}
