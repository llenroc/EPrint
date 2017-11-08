using EPrint.Services.Interfaces;
using EPrint.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EPrint.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilesPage : ContentPage
	{
        FilesPageViewModel vm;
        public FilesPage ()
		{
			InitializeComponent ();
            BindingContext = vm =  new FilesPageViewModel(DependencyService.Get<IFilePrintService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadCommand.Execute(null);

        }
    }
}