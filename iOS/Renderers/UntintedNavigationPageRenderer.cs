using System;
using KickassUI.Twitter.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(UntintedNavigationPageRenderer))]
namespace KickassUI.Twitter.iOS.Renderers
{
    public class UntintedNavigationPageRenderer : NavigationRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var item = this.NavigationBar?.TopItem?.LeftBarButtonItem;

            if (item != null)
                item.Image = item.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
        }
    }
}
