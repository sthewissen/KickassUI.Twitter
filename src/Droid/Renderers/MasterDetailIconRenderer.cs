using System;
using Android.Content;
using Android.Widget;
using KickassUI.Twitter.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(MasterDetailIconRenderer))]
namespace KickassUI.Twitter.Droid.Renderers
{
    public class MasterDetailIconRenderer : MasterDetailPageRenderer
    {
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            SetNavigationIcon(Forms.Context, Resource.Drawable.devnl_small);
        }

        private void SetNavigationIcon(Context context, int resourceId)
        {
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            var navIcon = toolbar.NavigationIcon.Callback as ImageButton;

            navIcon?.SetImageDrawable(context.GetDrawable(resourceId));
        }
    }
}
