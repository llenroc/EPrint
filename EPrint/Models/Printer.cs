using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Models
{
    public class Printer
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Url { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }
    }
}
