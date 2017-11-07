using EPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUser(User user);

        Task<User> UpdateUser(User user);
        Task<User> GetUserByEmail(string email);
    }
}
