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
        public string GetLocalFilePath(string filename)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(folderPath, filename);

            if (!File.Exists(filePath)) {
                File.Create(filePath);
            }
            return filePath;
        }
    }
}