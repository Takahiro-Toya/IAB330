using System;
using Xamarin.Forms;
using System.IO;
using SnackRoulette.iOS;
using SQLite;
using SnackRoulette.Database;

[assembly: Dependency(typeof(SQLite_IOS))]
namespace SnackRoulette.iOS
{
    public class SQLite_IOS : ISQLite
    {
        public SQLiteConnection GetSQLiteConnection()
        {
            var fileName = "Student.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}
