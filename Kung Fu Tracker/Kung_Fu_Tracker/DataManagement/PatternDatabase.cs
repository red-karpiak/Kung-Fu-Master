using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using Kung_Fu_Tracker.Interfaces;
using SQLite;

namespace Kung_Fu_Tracker.DataManagement
{
    public class PatternDatabase
    {
        SQLiteAsyncConnection database;
        public PatternDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PatternEntry>().Wait();
        }
    }
}
