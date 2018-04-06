using SQLite;
using Xamarin.Forms;
using Kung_Fu_Tracker.Interfaces;
using System.IO;

[assembly: Dependency(typeof(Kung_Fu_Tracker.Droid.Databasing.SQLiteAndroid))]
namespace Kung_Fu_Tracker.Droid.Databasing
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteAndroid() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "KungFuDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLiteConnection(path);

            return conn;
        } 
    }
}