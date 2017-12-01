using EPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Services.Local
{
    public static class Helper
    {
        public static bool SaveInternalUser(User user) {
            try
            {
                var u = new LocalUser()
                {
                    IdService = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    IsAdmin = user.IsAdmin
                };
                if (user.ImageUrl == "" || user.ImageUrl == null)
                {
                    u.ImageUrl = "user.png";
                }
                App.InternalDatabase.SaveUser(u);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
