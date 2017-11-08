using EPrint.Interfaces;
using EPrint.Models;
using EPrint.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EPrint.ViewModels.Pages
{
    public class FilesPageViewModel : ViewModelBase, IIconChange
    {
        #region Properties
        bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (SetProperty(ref isSelected, value))
                {
                    OnPropertyChanged(nameof(CurrentIcon));
                    OnPropertyChanged(nameof(CurrentTitle));
                }

            }
        }

        public string CurrentTitle
        {
            get => IsSelected ? "Archivos" : "";
        }
        public string CurrentIcon
        {
            get => IsSelected ? "filesSelected.png" : "files.png";
        }

        private List<FilePrint> filesToPrint;

        public List<FilePrint> FilesToPrint
        {
            get { return filesToPrint; }
            set { SetProperty(ref filesToPrint, value); }
        }

        public Command LoadCommand
        {
            get;
            set;
        }

        public Command AddCommand
        {
            get;
            set;
        }

        #endregion

        IFilePrintService service;

        

        public FilesPageViewModel(IFilePrintService service)
        {
            this.service = service;
            FilesToPrint = new List<FilePrint>();
            LoadCommand = new Command(async () => await Load());
            AddCommand = new Command(Add);
        }

        private async Task Load()
        {
            try
            {
                IsBusy = true;
                string idUser = App.InternalDatabase.GetUser().IdService;
                var files = await service.GetFilesUnprinted(idUser);
                foreach (var file in files)
                {
                    switch (file.Format)
                    {
                        case "Excel":
                            file.ImageUrl = "excel.png";
                            break;
                        case "Word":
                            file.ImageUrl = "word.png";
                            break;
                        case "PDF":
                            file.ImageUrl = "pdf.png";
                            break;
                        case "Power Point":
                            file.ImageUrl = "power.png";
                            break;
                    }
                    FilesToPrint.Add(file);
                }               
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                throw;
            }
        }

        public void Add() {

        }
    }
}
