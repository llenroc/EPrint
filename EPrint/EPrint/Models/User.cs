using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Models
{
    public class User
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public string Picture { get; set; }

        public string AccessToken { get; set; }
    }
}
