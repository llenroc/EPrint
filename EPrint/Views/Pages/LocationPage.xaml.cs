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
            myMap.CustomPins = vm.Pins;
            foreach (var pin in vm.Pins)
            {
                myMap.Pins.Add(pin);
            }
            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(
              new Position(-8.099946, -79.0201638), Distance.FromMeters(500.0)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadCommand.Execute(null);
            vm.CurrentLocationCommand.Execute(null);

        }
    }
}