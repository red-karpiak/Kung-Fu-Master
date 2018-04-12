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
    public class UserDBController
    {
        static object locker = new object();
        SQLiteConnection database;
        public UserDBController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }
        public User GetUser(User user)
        {
            lock (locker)
            {
                if (database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().FirstOrDefault(u => u.Password == user.Password && u.Username == user.Username);
                }
            }
        }
        public int SaveUser(User user)
        {
            lock (locker)
            {
                if (user.Id != 0)
                {
                    database.Update(user);
                    return user.Id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }
        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }
    }
}
