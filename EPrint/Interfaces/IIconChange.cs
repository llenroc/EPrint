using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Interfaces
{
    public interface IIconChange
    {
        string CurrentTitle { get; }
        bool IsSelected { get; set; }
        string CurrentIcon { get; }
    }
}
