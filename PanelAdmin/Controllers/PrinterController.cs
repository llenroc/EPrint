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
    public class PrinterController : Controller
    {
        // GET: Printer
        public async Task<ActionResult> Index()
        {
            List<Printer> printers = new List<EPrint.Models.Printer>();
            var printerTable = App.MobileService.GetTable<Printer>();
            printers = await printerTable.ToListAsync();

            return View(printers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Printer printer)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                if (printer != null)
                {
                    try
                    {
                        var userTable = App.MobileService.GetTable<Printer>();
                        await userTable.InsertAsync(printer);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }
            return RedirectToAction("Index", "Printer");
        }
    }
}