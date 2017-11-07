using EPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Services.Interfaces
{
    public interface IFilePrint
    {
        Task<List<FilePrint>> GetAllFiles();
        Task<List<FilePrint>> GetFilesPrinted();
        Task<List<FilePrint>> GetFilesUnprinted();
    }
}
