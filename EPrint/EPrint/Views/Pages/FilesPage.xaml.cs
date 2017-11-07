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
		public FilesPage ()
		{
			InitializeComponent ();
            BindingContext = new FilesPageViewModel();
        }
	}
}