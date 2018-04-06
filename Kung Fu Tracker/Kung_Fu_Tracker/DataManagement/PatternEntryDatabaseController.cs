using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Kung_Fu_Tracker.Interfaces;

namespace Kung_Fu_Tracker.DataManagement
{
    //database controller for the patterns
    public class PatternEntryDatabaseController
    {
        static object locker = new object();
        SQLiteConnection database;
        public PatternEntryDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<PatternEntry>();
        }
        public PatternEntry GetPatternEntry()
        {
            lock (locker)
            {
                if (database.Table<PatternEntry>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<PatternEntry>().First();
                }
            }
        }
        public int SavePatternEntry(PatternEntry patternEntry)
        {
            lock (locker)
            {
                if (patternEntry.ID != 0)
                {
                    database.Update(patternEntry);
                    return patternEntry.ID;
                }
                else
                {
                    return database.Insert(patternEntry);
                }
            }
        }
        public int DeletePatternEntry(int id)
        {
            lock (locker)
            {
                return database.Delete<PatternEntry>(id);
            }
        }
    }
}
