using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace EPrint.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init(@"Kqgqr58cuT9IshOahSwc~xkChqwBifMrryXi_mZKjwg~AnKDrkEWFwVC01B0DNRZrlgyG3bfoSH6k_MQB1UBTz4i2R_yFmf20TLFTot7Cf2N");
            LoadApplication(new EPrint.App());
        }
    }
}
