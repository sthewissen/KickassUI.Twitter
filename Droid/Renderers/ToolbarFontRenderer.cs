using System;
using Android.Graphics;
using KickassUI.Twitter.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(ToolbarFontRenderer))]
namespace KickassUI.Twitter.Droid.Renderers
{
    public class ToolbarFontRenderer : NavigationPageRenderer
    {
        private Android.Support.V7.Widget.Toolbar toolbar;


        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);
            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                toolbar = (Android.Support.V7.Widget.Toolbar)child;
                toolbar.ChildViewAdded += Toolbar_ChildViewAdded;

                toolbar.SetNavigationIcon(Resource.Drawable.devnl);
            }
        }

        private void Toolbar_ChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {
            var view = e.Child.GetType();
            if (e.Child.GetType() == typeof(Android.Widget.TextView))
            {
                var textView = (Android.Widget.TextView)e.Child;
                var spaceFont = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.ApplicationContext.Assets, "Roboto-Bold.ttf");
                textView.Typeface = spaceFont;
                toolbar.ChildViewAdded -= Toolbar_ChildViewAdded;
            }
        }
    }
}
