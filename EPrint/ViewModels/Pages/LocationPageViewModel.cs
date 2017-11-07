using EPrint.Controls;
using EPrint.Interfaces;
using EPrint.Services.Interfaces;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace EPrint.ViewModels.Pages
{
    public class LocationPageViewModel : ViewModelBase, IIconChange
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
            get => IsSelected ? "Ubicación" : "";
        }
        public string CurrentIcon
        {
            get => IsSelected ? "locationSelected.png" : "location.png";
        }

        private List<CustomPin> _pins;

        public List<CustomPin> Pins
        {
            get { return _pins; }
            set { SetProperty(ref _pins, value); }
        }

        private double _latitude;

        public double Latitude
        {
            get { return _latitude; }
            set { SetProperty(ref _latitude, value); }
        }

        private double _longitude;

        public double Longitude
        {
            get { return _longitude; }
            set { SetProperty(ref _longitude, value); }
        }

        public Command LoadCommand
        {
            get;
            set;
        }

        public Command CurrentLocationCommand
        {
            get;
            set;
        }


        #endregion

        IPrinterService service;

        public LocationPageViewModel(IPrinterService service)
        {
            this.service = service;
            Pins = new List<CustomPin>();
            LoadCommand = new Command(async () => await Load());
            CurrentLocationCommand = new Command(async () => await GetLocation());
        }

        private async Task Load()
        {
            try
            {
                IsBusy = true;
                var printers = await service.AllPrinters();

                foreach (var print in printers)
                {
                    Pins.Add(new CustomPin()
                    {
                        Type = PinType.Place,
                        Position = new Position(print.Lat, print.Long),
                        Label = print.Name,
                        Address = print.Address,
                        Id = print.Id,
                        Url = print.Url
                    });
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                throw;
            }
            
        }

        private async Task GetLocation()
        {
            IsBusy = true;
            Plugin.Geolocator.Abstractions.Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    Latitude = position.Latitude;
                    Longitude = position.Longitude;
                    IsBusy = false;
                }
                else
                {
                    if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                    {
                        await App.Current.MainPage.DisplayAlert("Ubicación", "Tu ubicación no está encendida", "OK");
                    }
                    position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
                    IsBusy = false;
                    Latitude = position.Latitude;
                    Longitude = position.Longitude;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                //Display error as we have timed out or can't get location.
            }
        }

    }
}
