﻿using EPrint.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPrint.Models;

namespace EPrint.Services
{
    public class FilePrintService : IFilePrint
    {
        public async Task<List<FilePrint>> GetAllFiles()
        {
            List<FilePrint> files = new List<FilePrint>();
            try
            {
                var filePrinterTable = App.MobileService.GetTable<FilePrint>();
                files = await filePrinterTable.ToListAsync();
                return files;
            }
            catch (Exception ex)
            {
                return files;
            }
        }

        public async Task<List<FilePrint>> GetFilesPrinted(string IdUser)
        {
            List<FilePrint> files = new List<FilePrint>();
            try
            {
                var filePrinterTable = App.MobileService.GetTable<FilePrint>();
                files = await filePrinterTable.Where(x => x.IsPrinted && x.UserId == IdUser).ToListAsync();
                return files;
            }
            catch (Exception ex)
            {
                return files;
            }
        }

        public async Task<List<FilePrint>> GetFilesUnprinted(string idUser)
        {
            List<FilePrint> files = new List<FilePrint>();
            try
            {
                var filePrinterTable = App.MobileService.GetTable<FilePrint>();
                files = await filePrinterTable.Where(x => !x.IsPrinted && x.UserId == idUser).ToListAsync();
                return files;
            }
            catch (Exception ex)
            {
                return files;
            }
        }
    }
}
