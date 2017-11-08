using EPrint;
using EPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PanelAdmin.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> Index()
        {
            List<User> users = new List<EPrint.Models.User>();
                var userTable = App.MobileService.GetTable<User>();
                users = await userTable.ToListAsync();
            
            return View(users);
        }
    }
}