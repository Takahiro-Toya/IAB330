using System.IO;
using SnackRoulette.Database;
using SnackRoulette.Droid.Dependancies;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace SnackRoulette.Droid.Dependancies
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }
        public SQLite.SQLiteConnection GetSQLiteConnection()
        {
            var fileName = "users.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, fileName);

            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}
