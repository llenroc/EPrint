using EPrint.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace EPrint.ViewModels
{
    public class StartPageViewModel :ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public INavigation Navigation { get; set; }


        public StartPageViewModel()
        {
            LoginCommand = new Command(NavigateToLogin);
            RegisterCommand = new Command(NavigateToRegister);
        }

        private void NavigateToLogin()
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void NavigateToRegister()
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
