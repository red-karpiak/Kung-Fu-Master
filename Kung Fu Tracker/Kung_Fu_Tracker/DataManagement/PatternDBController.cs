using Kung_Fu_Tracker.Interfaces;
using Kung_Fu_Tracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.DataManagement
{
    public class PatternDBController
    {
        static object locker = new object();
        SQLiteConnection database;
        public PatternDBController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Pattern>();
        }
        public Pattern GetPattern()
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
        public int SaveToken(Pattern pattern)
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
        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Pattern>(id);
            }
        }

    }
}
