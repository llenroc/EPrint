using EPrint.Interfaces;
using EPrint.Models;
using EPrint.Services.Interfaces;
using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<FilePrint> filesToPrint;

        public ObservableCollection<FilePrint> FilesToPrint
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
            FilesToPrint = new ObservableCollection<FilePrint>();
            LoadCommand = new Command(async () => await Load());
            AddCommand = new Command(async () => await Add());
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

        public async Task Add()
        {
            var file = await CrossFilePicker.Current.PickFile();
            string format = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);
            string formatToFile = "";
            string urlImage = "";
            
            switch (format)
            {
                case "doc":
                    formatToFile = "Word";
                    urlImage = "word.png";
                    break;
                case "docx":
                    formatToFile = "Word";
                    urlImage = "word.png";
                    break;
                case "pdf":
                    formatToFile = "PDF";
                    urlImage = "pdf.png";
                    break;
                case "ppt":
                    formatToFile = "Power Point";
                    urlImage = "power.png";
                    break;
                case "pptx":
                    formatToFile = "Power Point";
                    urlImage = "power.png";
                    break;
                case "xls":
                    formatToFile = "Excel";
                    urlImage = "excel.png";
                    break;
                case "xlsx":
                    formatToFile = "Excel";
                    urlImage = "excel.png";
                    break;
                
            }
            if (formatToFile != "")
            {
                FilePrint fileToPrint = new FilePrint()
                {
                    Name = file.FileName,
                    Format = formatToFile,
                    IsPrinted = false,
                    UserId = App.InternalDatabase.GetUser().IdService,
                    Size = NormalizeFileSize(file.DataArray.Length),
                    Description = DateTime.Today.ToString(),
                    ImageUrl = urlImage
                };
                var wasAdded = await service.AddFile(fileToPrint);
                if (wasAdded)
                {
                    FilesToPrint.Add(fileToPrint);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Algo ha pasado :(", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Formato no soportado", "Ok");
            }

        }

        private string NormalizeFileSize(int fileSize)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            double size = fileSize;
            int unit = 0;
            while (size >= 1024)
            {
                size /= 1024;
                ++unit;
            }
            return $"{size:0.#} {units[unit]}";
        }
    }
}
