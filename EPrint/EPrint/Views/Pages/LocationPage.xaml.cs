using EPrint.Controls;
using EPrint.Services.Interfaces;
using EPrint.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace EPrint.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationPage : ContentPage
	{
        LocationPageViewModel vm;
		public LocationPage ()
		{
			InitializeComponent ();
            BindingContext = vm = new LocationPageViewModel(DependencyService.Get<IPrinterService>());

            myMap.CustomPins = new List<CustomPin> {  new CustomPin()
            {
                Type = PinType.Place,
                Position = new Position(-8.1003067, -79.0212477),
                Label = "Impresiones Juanita ",
                Address = "Borgoños 359",
                Id = "sss",
                Url = "http://google.com"
            },new CustomPin()
            {
                Type = PinType.Place,
                Position = new Position(-8.0995317, -79.0212687),
                Label = "Fotocopias Petter",
                Address = "Av. Ejercito 991",
                Id = "sss",
                Url = "http://google.com"
            }
            };

            

            foreach (var item in myMap.CustomPins)
            {
                myMap.Pins.Add(item);
            }
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(
              new Position(-8.0998823, -79.0212474), Distance.FromMeters(500.0)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadCommand.Execute(null);
            vm.CurrentLocationCommand.Execute(null);
           
        }
    }
}