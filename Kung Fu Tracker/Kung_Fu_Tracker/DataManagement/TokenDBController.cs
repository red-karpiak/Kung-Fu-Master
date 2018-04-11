using SQLite;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kung_Fu_Tracker.Interfaces;
using Kung_Fu_Tracker.Models;

namespace Kung_Fu_Tracker.DataManagement
{
    public class TokenDBController
    {
        static object locker = new object();
        SQLiteConnection database;
        public TokenDBController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Token>();
        }
        //public Token GetToken(Token token)
        public Token GetToken()
        {
            lock (locker)
            {
                if (database.Table<Token>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }
        public int SaveToken(Token token)
        {
            lock (locker)
            {
                if (token.Id != 0)
                {
                    database.Update(token);
                    return token.Id;
                }
                else
                {
                    return database.Insert(token);
                }
            }
        }
        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}
