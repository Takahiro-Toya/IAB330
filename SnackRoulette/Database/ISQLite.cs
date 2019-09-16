using System;
using SQLite;

namespace SnackRoulette.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
