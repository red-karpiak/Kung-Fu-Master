using SQLite;
using Xamarin.Forms;
using Kung_Fu_Tracker.Interfaces;
using System.IO;
using System;

[assembly: Dependency(typeof(Kung_Fu_Tracker.Droid.Databasing.SQLiteAndroid))]
namespace Kung_Fu_Tracker.Droid.Databasing
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "AppDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLiteConnection(path);
            return null;
        }
    }
}