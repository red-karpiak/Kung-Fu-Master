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
        
        SQLiteAsyncConnection database;
        public PatternDatabaseController(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Pattern>().Wait();
        }
        public Task<List<Pattern>> GetPatternAsync(string rank)
        {
            return database.QueryAsync<Pattern>("SELECT * FROM [Pattern] WHERE [Rank] = rank [ORDER BY Order]");
        }

        public Task<Pattern> GetPatternEntryAsync(int id)
        {
            return database.Table<Pattern>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SavePatternEntryAsync(Pattern pattern)
        {
            if (pattern.ID != 0)
            {
                return database.UpdateAsync(pattern);
            }
            else
            {
                return database.InsertAsync(pattern);
            }
        }
        public Task<int> DeleteItemAsync(Pattern pattern)
        {
            return database.DeleteAsync(pattern);
        }

    }
}
