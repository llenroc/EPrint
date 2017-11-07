using EPrint.Models.MasterDetail;
using EPrint.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.ViewModels.MasterDetail
{
    public class MasterPageViewModel : ViewModelBase
    {
        #region Properties
        private List<MasterPageItem> _items;

        public List<MasterPageItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }

        private string urlImage;

        public string UrlImage
        {
            get { return urlImage; }
            set { SetProperty(ref urlImage, value); }
        }

        #endregion


        public MasterPageViewModel()
        {
            Items = new List<MasterPageItem>();
            Load();
        }

        private void Load()
        {
            Items.Add(new MasterPageItem
            {
                Title = "Inicio",
                Icon = "fa-home",
                Target = typeof(HomePage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Archivos",
                Icon = "fa-file-text-o",
                Target = typeof(FilesPage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Ubicación",
                Icon = "fa-map-marker",
                Target = typeof(LocationPage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Historial",
                Icon = "fa-history",
                Target = typeof(HistoryPage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Ajustes",
                Icon = "fa-cog",
                Target = typeof(HistoryPage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Imprentas a tu alrededor",
                Icon = "fa-print",
                Target = typeof(HistoryPage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Comparte la app",
                Icon = "fa-share-alt",
                Target = typeof(HistoryPage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Puntúanos",
                Icon = "fa-star",
                Target = typeof(HistoryPage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Contáctanos",
                Icon = "fa-phone",
                Target = typeof(HistoryPage)
            });
            Items.Add(new MasterPageItem
            {
                Title = "Cerrar sesión",
                Icon = "fa-sign-out",
                Target = typeof(HistoryPage)
            });

            var user = App.InternalDatabase.GetUser();
            UserName = user.Name;
            UrlImage = user.ImageUrl;
            
        }
    }
}
