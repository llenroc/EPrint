using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EPrint.Services.Local
{
    public class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<LocalUser>();
        }
        public List<LocalUser> GetAllUsers()
        {
            return dbConn.Query<LocalUser>("Select * From [LocalUser]");
        }

        public LocalUser GetUser()
        {
            return dbConn.Table<LocalUser>().FirstOrDefault();
        }
        public int SaveUser(LocalUser user)
        {
            return dbConn.Insert(user);
        }
        public int DeleteUser(LocalUser user)
        {
            return dbConn.Delete(user);
        }
        public int EditUser(LocalUser user)
        {
            return dbConn.Update(user);
        }
    }
}
