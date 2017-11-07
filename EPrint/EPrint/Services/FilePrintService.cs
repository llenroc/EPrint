using EPrint.Services.Interfaces;
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
        public Task<List<FilePrint>> GetAllFiles()
        {
            throw new NotImplementedException();
        }

        public Task<List<FilePrint>> GetFilesPrinted()
        {
            throw new NotImplementedException();
        }

        public Task<List<FilePrint>> GetFilesUnprinted()
        {
            throw new NotImplementedException();
        }
    }
}
