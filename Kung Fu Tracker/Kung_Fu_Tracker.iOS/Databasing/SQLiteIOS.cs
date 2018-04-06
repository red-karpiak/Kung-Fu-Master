using System;
using Kung_Fu_Tracker.Interfaces;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Kung_Fu_Tracker.iOS.Databasing;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace Kung_Fu_Tracker.iOS.Databasing
{
    public class SQLiteIOS : ISQLite
    {
        public SQLiteIOS() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "KungFuDB.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);
            var conn = new SQLiteConnection(path);

            return conn;
        }
    }
}