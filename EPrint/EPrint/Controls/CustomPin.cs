using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace EPrint.Controls
{
    public class CustomPin : Pin
    {
        public string Id { get; set; }
        public string Url { get; set; }
    }
}
