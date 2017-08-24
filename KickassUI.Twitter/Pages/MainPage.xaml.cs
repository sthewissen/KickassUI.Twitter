using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KickassUI.Twitter.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Don't need toolbar items here.
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    this.ToolbarItems.Clear();
                    break;
            }
        }
    }
}
