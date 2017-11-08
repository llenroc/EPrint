using EPrint.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Services.Interfaces
{
    public interface IFilePrintService
    {
        Task<bool> AddFile(FilePrint file);
        Task<List<FilePrint>> GetAllFiles();
        Task<List<FilePrint>> GetFilesPrinted(string IdUser);
        Task<List<FilePrint>> GetFilesUnprinted(string IdUser);
    }
}
