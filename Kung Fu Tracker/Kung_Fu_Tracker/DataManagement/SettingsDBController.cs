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
    public class SettingsDBController
    {
        static object locker = new object();
        SQLiteConnection database;
        public SettingsDBController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Settings>();
        }
        //public Token GetToken(Token token)
        public Settings GetSettings()
        {
            lock (locker)
            {
                if (database.Table<Settings>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Settings>().First();
                }
            }
        }
        public int SaveSettings(Settings settings)
        {
            lock (locker)
            {
                if (settings.ID != 0)
                {
                    database.Update(settings);
                    return settings.ID;
                }
                else
                {
                    settings.ID = 1;
                    return database.Insert(settings);
                }
            }
        }
        public int DeleteSettings(int id)
        {
            lock (locker)
            {
                return database.Delete<Settings>(id); 
            }
        }
    }
}
