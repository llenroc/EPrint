using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin.Auth;
using EPrint.Views;
using EPrint.Droid.Renderers;

[assembly: ExportRenderer(typeof(LoginTransitionPage), typeof(LoginTransitionPageRenderer))]
namespace EPrint.Droid.Renderers
{
    public class LoginTransitionPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            // this is a ViewGroup - so should be able to load an AXML file and FindView<>
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: EPrint.Resources.Facebook.Variables.ClientId, // your OAuth2 client id
                scope: EPrint.Resources.Facebook.Variables.Scope, // The scopes for the particular API you're accessing. The format for this will vary by API.
                authorizeUrl: new Uri(EPrint.Resources.Facebook.Variables.AuthorizeUrl), // the auth URL for the service
                redirectUrl: new Uri(EPrint.Resources.Facebook.Variables.RedirectUrl)); // the redirect URL for the service

            auth.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    var token = eventArgs.Account.Properties["access_token"];
                    var main = App.Current.MainPage;
                    MessagingCenter.Send<LoginPage, string>((LoginPage)main, "GetUser", token);
                    //App.Instance.NavigateToMain();
                }
                else
                {
                    // The user cancelled
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}