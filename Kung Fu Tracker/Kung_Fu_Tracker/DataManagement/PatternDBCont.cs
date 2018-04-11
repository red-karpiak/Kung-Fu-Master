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
    public class PatternDBCont
    {
        //The advantage of using the asynchronous SQLite.Net API is that database 
        //operations are moved to background threads. In addition, 
        //there's no need to write additional concurrency handling code because the API takes care of it.

        SQLiteAsyncConnection database;
        public PatternDBCont(string dbPath)
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
