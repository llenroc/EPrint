using EPrint.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPrint.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.IO;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using EPrint.Resources;
using EPrint.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(UserService))]
namespace EPrint.Services
{
    public class UserService : IUserService
    {
        public async Task<bool> AddUser(User user)
        {
            try
            {
                var userTable = App.MobileService.GetTable<User>();
                await userTable.InsertAsync(user);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = null;
            try
            {
                var tabla = App.MobileService.GetTable<User>();
                var users = await tabla.Where(x => x.Email == email).Take(1).ToListAsync();
                user = users.FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                return user;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                var tabla = App.MobileService.GetTable<User>();
                await tabla.UpdateAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
