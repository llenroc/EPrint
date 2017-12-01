using EPrint.Helpers;
using EPrint.Models;
using EPrint.Resources;
using EPrint.Services.Interfaces;
using EPrint.Services.Local;
using EPrint.Views;
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
    public class LoginPageViewModel : ViewModelBase
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

        public ICommand LoginCommand { get; set; }
        public ICommand RecoveryCommand { get; set; }
        public ICommand LoginFacebookCommand { get; set; }
        public INavigation Navigation { get; set; }

        #endregion

        IUserService service;

        public LoginPageViewModel(IUserService service)
        {
            this.service = service;
            LoginCommand = new Command(async () => await Login());
            LoginFacebookCommand = new Command(async () => await LoginFacebook());
            MessagingCenter.Subscribe<LoginPage, string>(this, "GetUser", async (sender, token) =>
            {

                var u = await EPrint.Services.Facebook.Service.GetUserAsync(token);

                var user = await service.GetUserByEmail(u.Email);
                if (user != null)
                {
                    var pass = Crypto.EncryptAes(Password, Variables.PasswordKey);
                    if (user.Password == pass)
                    {
                        Helper.SaveInternalUser(user);
                        IsBusy = false;
                        Settings.IsLogin = true;
                        Application.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        ErrorMessage = "Usuario o contraseña invalidos";
                    }

                }
                else
                {
                    var isRegistered = await service.AddUser(user);
                    if (isRegistered)
                    {
                        Helper.SaveInternalUser(user);
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
            });
        }

        private async Task Login()
        {
            IsBusy = true;
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    var user = await service.GetUserByEmail(Email);
                    if (user != null)
                    {
                        var pass = Crypto.EncryptAes(Password, Variables.PasswordKey);
                        if (user.Password == pass)
                        {
                            var u = new LocalUser()
                            {
                                IdService = user.Id,
                                Name = user.Name,
                                Email = user.Email,
                                Password = user.Password,
                                IsAdmin = user.IsAdmin
                            };
                            if (user.Picture == "" || user.Picture == null)
                            {
                                u.ImageUrl = "user.png";
                            }
                            App.InternalDatabase.SaveUser(u);
                            IsBusy = false;
                            Settings.IsLogin = true;
                            Application.Current.MainPage = new MainPage();
                        }
                        else
                        {
                            ErrorMessage = "Usuario o contraseña invalidos";
                        }

                    }
                    else
                    {
                        IsBusy = false;
                        ErrorMessage = "Usuario o contraseña invalidos";
                    }

                }
                else
                {
                    IsBusy = false;
                    await App.Current.MainPage.DisplayAlert("Error de conexión", "Tu conexión a internet está fallando", "Ok");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorMessage = ex.Message;
            }
        }

        private async Task LoginFacebook()
        {
            await Navigation.PushAsync(new LoginTransitionPage());
        }
    }
}
