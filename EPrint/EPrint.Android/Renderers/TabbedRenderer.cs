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
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms;
using EPrint.Views.MasterDetail;
using Android.Support.Design.Widget;
using EPrint.Interfaces;
using Xamarin.Forms.Platform.Android;
using System.IO;
using Android.Support.V4.View;

[assembly: ExportRenderer(typeof(Tabbed), typeof(EPrint.Droid.Renderers.TabbedRenderer))]
namespace EPrint.Droid.Renderers
{
    public class TabbedRenderer : TabbedPageRenderer
    {
        TabLayout layout;
        public TabbedRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);
            if (Element != null)
            {
                ((Tabbed)Element).UpdateIcons += Handle_UpdateIcons;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);


            if (layout == null && e.PropertyName == "Renderer")
            {
                layout = (TabLayout)ViewGroup.GetChildAt(1);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            InvertLayoutThroughScale();

            base.OnLayout(changed, l, t, r, b);
        }

        void Handle_UpdateIcons(object sender, EventArgs e)
        {
            TabLayout tabs = layout;

            if (tabs == null)
                return;

            for (var i = 0; i < Element.Children.Count; i++)
            {
                var child = Element.Children[i].BindingContext as IIconChange;
                var icon = child.CurrentIcon;
                if (string.IsNullOrEmpty(icon))
                    continue;

                TabLayout.Tab tab = tabs.GetTabAt(i);
                SetCurrentTabIcon(tab, icon);
            }
        }

        void SetCurrentTabIcon(TabLayout.Tab tab, string icon)
        {
            tab.SetIcon(IdFromTitle(icon, ResourceManager.DrawableClass));
        }

        int IdFromTitle(string title, Type type)
        {
            string name = Path.GetFileNameWithoutExtension(title);
            int id = GetId(type, name);
            return id;
        }

        int GetId(Type type, string memberName)
        {
            object value = type.GetFields().FirstOrDefault(p => p.Name == memberName)?.GetValue(type)
                ?? type.GetProperties().FirstOrDefault(p => p.Name == memberName)?.GetValue(type);
            if (value is int)
                return (int)value;
            return 0;
        }


        private void InvertLayoutThroughScale()
        {
            ViewGroup.ScaleY = -1;

            TabLayout tabLayout = null;
            ViewPager viewPager = null;

            for (int i = 0; i < ChildCount; ++i)
            {
                Android.Views.View view = (Android.Views.View)GetChildAt(i);
                if (view is TabLayout) tabLayout = (TabLayout)view;
                else if (view is ViewPager) viewPager = (ViewPager)view;
            }

            viewPager.ScaleY = -1;
            viewPager.SetPadding(0, -tabLayout.MeasuredHeight, 0, 0);
        }

    }
}