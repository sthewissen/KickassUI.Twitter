using System;
using KickassUI.Twitter.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TitlelessTabBarRenderer))]
namespace KickassUI.Twitter.iOS.Renderers
{
    public class TitlelessTabBarRenderer : TabbedRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            if (TabBar?.Items == null)
                return;

            var tabs = Element as TabbedPage;

            if (tabs != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                {
                    UpdateTabBarItem(TabBar.Items[i], tabs.Children[i].Icon);
                }
            }

            base.ViewWillAppear(animated);
        }

        private void UpdateTabBarItem(UITabBarItem item, string icon)
        {
            if (item == null)
                return;

            icon = icon.Replace(".png", "_selected.png");

            if (item?.SelectedImage?.AccessibilityIdentifier == icon)
                return;

            item.SelectedImage = UIImage.FromBundle(icon);
            item.SelectedImage.AccessibilityIdentifier = icon;

            item.Title = string.Empty;
            item.ImageInsets = new UIEdgeInsets(top: 6, left: 0, bottom: -6, right: 0);
        }
    }
}

