using EPrint.Helpers;
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

        #endregion

        IUserService service;

        public LoginPageViewModel(IUserService service)
        {
            this.service = service;
            LoginCommand = new Command(async () => await Login());
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
                        var pass =  Crypto.EncryptAes(Password, Variables.PasswordKey);
                        if (user.Password == pass)
                        {
                            var u = new LocalUser()
                            {
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
    }
}
