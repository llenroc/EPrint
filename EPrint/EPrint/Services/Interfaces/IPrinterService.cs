using EPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Services.Interfaces
{
    public interface IPrinterService
    {
        Task<List<Printer>> AllPrinters();

    }
}
