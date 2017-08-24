using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using KickassUI.Twitter.Models;
using Xamarin.Forms;

namespace KickassUI.Twitter.PageModels
{
    public class MenuPageModel : FreshBasePageModel
    {
        public ObservableCollection<CustomMenuItem> MenuItems { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            MenuItems = new ObservableCollection<CustomMenuItem>();

            MenuItems.Add(new CustomMenuItem() { IconVisible = true, Icon = @"", Text = "Profiel" });
            MenuItems.Add(new CustomMenuItem() { IconVisible = true, Icon = @"", Text = "Lijsten" });
            MenuItems.Add(new CustomMenuItem() { IconVisible = true, Icon = @"", Text = "Momenten" });
            MenuItems.Add(new CustomMenuItem() { IconVisible = true, Icon = @"", Text = "Hoogtepunten" });
        }
    }
}
