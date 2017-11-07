using EPrint.Helpers;
using EPrint.Resources;
using EPrint.Services.Local;
using EPrint.Views;
using EPrint.Views.MasterDetail;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EPrint
{
    public partial class App : Application
    {
        public static DataAccess dbUtils;
        public static MobileServiceClient MobileService = new MobileServiceClient(Variables.UrlApp);
        public static DataAccess InternalDatabase
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }
        public App()
        {
            InitializeComponent();
            if (Settings.IsLogin)
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new NavigationPage(new StartPage());
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
