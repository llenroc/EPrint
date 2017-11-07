using EPrint.Helpers;
using EPrint.Models;
using EPrint.Resources;
using EPrint.Services.Interfaces;
using EPrint.Services.Local;
using EPrint.Views.MasterDetail;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EPrint.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        #region Properties
        private string _email;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand RegisterCommand { get; set; }

        #endregion

        IUserService service;

        public RegisterPageViewModel(IUserService service)
        {
            this.service = service;
            RegisterCommand = new Command(async () => await Register());
        }

        private async Task Register()
        {
            IsBusy = true;
            ErrorMessage = "";
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    if (Email != null && Password != null)
                    {
                        User user = new User()
                        {
                            Email = Email,
                            Password = Crypto.EncryptAes(Password, Variables.PasswordKey),
                            IsAdmin = false
                        };
                        var isRegistered = await service.AddUser(user);
                        if (isRegistered)
                        {
                            var u = new LocalUser()
                            {
                                IdService = user.Id,
                                Name = user.Name,
                                Email = user.Email,
                                Password = user.Password,
                                IsAdmin = user.IsAdmin
                            };
                            if (user.ImageUrl == "" || user.ImageUrl == null)
                            {
                                u.ImageUrl = "user.png";
                            }
                            App.InternalDatabase.SaveUser(u);
                            IsBusy = false;
                            Settings.IsLogin = true;
                            App.Current.MainPage = new MainPage();
                        }
                        else
                        {
                            IsBusy = false;
                            ErrorMessage = "Algo ha pasado :(";
                        }
                    }
                    else
                    {
                        IsBusy = false;
                        ErrorMessage = "Todos los campos son obigatorios";
                    }
                    
                }
                else
                {
                    IsBusy = false;
                    await App.Current.MainPage.DisplayAlert("Error de conexión", "Tu conexión a internet está fallando","Ok");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorMessage = ex.Message;
            }
        }
    }
}
