using EPrint.Models.MasterDetail;
using EPrint.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EPrint.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Master = masterPage;
            masterPage.ListView.ItemSelected += OnItemSelected;
            MasterBehavior = MasterBehavior.Popover;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                switch (item.Title)
                {
                    case "Inicio":
                        Tabbed.CurrentTabbed.CurrentPage = Tabbed.CurrentTabbed.Children[0];
                        break;
                    case "Historial":
                        Tabbed.CurrentTabbed.CurrentPage = Tabbed.CurrentTabbed.Children[1];
                        break;
                    case "Archivos":
                        Tabbed.CurrentTabbed.CurrentPage = Tabbed.CurrentTabbed.Children[2];
                        break;
                    case "Ubicación":
                        Tabbed.CurrentTabbed.CurrentPage = Tabbed.CurrentTabbed.Children[3];
                        break;
                    default:
                        
                        break;
                }
                
                //Detail = new NavigationPage((Page)Activator.CreateInstance(item.Target));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }


    }
}