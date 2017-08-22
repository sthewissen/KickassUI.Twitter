using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Touch;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace KickassUI.Twitter.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            CachedImageRenderer.Init();
            LoadApplication(new App());

            UINavigationBar.Appearance.TintColor = Color.FromHex("#1fa3f5").ToUIColor();
            UITabBar.Appearance.TintColor = Color.FromHex("#1fa3f5").ToUIColor();
            UITabBar.Appearance.BarTintColor = UIColor.White;

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = UIFont.FromName("HelveticaNeue-Bold", 18)
            });

            return base.FinishedLaunching(app, options);
        }
    }
}
