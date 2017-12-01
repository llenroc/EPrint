using EPrint.Services.Interfaces;
using EPrint.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EPrint.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel vm;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = vm = new LoginPageViewModel(DependencyService.Get<IUserService>());
            vm.Navigation = Navigation;
        }
    }
}