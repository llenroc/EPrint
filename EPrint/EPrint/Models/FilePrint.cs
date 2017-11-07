using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Models
{
    public class FilePrint
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public bool IsPrinted { get; set; }
        public string UserId { get; set; }
        public string PrinterId { get; set; }
    }
}
