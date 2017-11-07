using EPrint.ViewModels.MasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EPrint.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return navigationDrawerList; } }
        public MasterPage()
        {
            InitializeComponent();
            BindingContext = new MasterPageViewModel();
        }
    }
}