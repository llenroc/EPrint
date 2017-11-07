﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Services.Local
{
    public class LocalUser
    {
        [PrimaryKey, AutoIncrement]
        public long Id
        { get; set; }
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public string ImageUrl { get; set; }
    }
}
