using EPrint.Interfaces;
using FormsPlugin.Iconize;
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
    public partial class Tabbed : TabbedPage
    {
        Page currentPage;

        static Tabbed instance = null;
        public static Tabbed CurrentTabbed
        {
            get
            {
                return instance;
            }
        }


        public Tabbed()
        {
            InitializeComponent();
            currentPage = Children[0];
            instance = this;
            CurrentPageChanged += Handle_CurrentPageChanged;
        }

        public event EventHandler UpdateIcons;
        void Handle_CurrentPageChanged(object sender, EventArgs e)
        {
            var currentBinding = currentPage.BindingContext as IIconChange;
            if (currentBinding != null)
                currentBinding.IsSelected = false;

            currentPage = CurrentPage;
            currentBinding = currentPage.BindingContext as IIconChange;
            if (currentBinding != null)
            {
                currentBinding.IsSelected = true;
                Title = currentBinding.CurrentTitle;
            }


            UpdateIcons?.Invoke(this, EventArgs.Empty);
        }
    }
}