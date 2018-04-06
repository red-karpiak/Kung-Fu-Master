using Kung_Fu_Tracker.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.DataManagement
{
    public class PatternDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;
        public PatternDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<PatternEntry>();
        }
        public Pattern GetPatternEntry()
        {
            lock (locker)
            {
                if (database.Table<Pattern>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Pattern>().First();
                }
            }
        }
        public int SavePattern(Pattern pattern)
        {
            lock (locker)
            {
                if (pattern.ID != 0)
                {
                    database.Update(pattern);
                    return pattern.ID;
                }
                else
                {
                    return database.Insert(pattern);
                }
            }
        }
        public int DeletePattern(string rank)
        {
            lock (locker)
            {
                return database.Delete<Pattern>(rank);
            }
        }
    }
}
