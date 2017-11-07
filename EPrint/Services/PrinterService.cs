using EPrint.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPrint.Models;
using Xamarin.Forms;
using EPrint.Services;

[assembly: Dependency(typeof(PrinterService))]
namespace EPrint.Services
{
    public class PrinterService : IPrinterService
    {
        public async Task<List<Printer>> AllPrinters()
        {
            List<Printer> printers = new List<Printer>();
            try
            {
                var printerTable = App.MobileService.GetTable<Printer>();
                printers = await printerTable.ToListAsync();
                return printers;
            }
            catch (Exception ex)
            {
                return printers;
            }
        }
    }
}
