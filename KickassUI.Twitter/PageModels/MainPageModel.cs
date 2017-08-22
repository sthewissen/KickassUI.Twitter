using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using KickassUI.Twitter.Models;

namespace KickassUI.Twitter.PageModels
{
    public class MainPageModel : FreshBasePageModel
    {
        public ObservableCollection<Tweet> Tweets { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            Tweets = new ObservableCollection<Tweet>();
            Tweets.Add(new Tweet()
            {
                PostDate = "16m",
                TweetText = "dotnet sdk list and dotnet sdk latest via @shanselman hanselman.com/blog/dotnetSdk...",
                UserFullName = "Donovan Brown",
                Username = "@DonovanBrown",
                UserImageUrl = "https://pbs.twimg.com/profile_images/897943933673627649/jplKYFXu_400x400.jpg",
                TweetImageAttachmentUrl = "https://pbs.twimg.com/media/DH0sXocXgAA1kSL.jpg"
            });
            Tweets.Add(new Tweet()
            {
                PostDate = "31m",
                TweetText = "Looks like 2.0 of @dotnet is on the @VSTS Hosted VS2017 build agents now.",
                UserFullName = "Donovan Brown",
                Username = "@DonovanBrown",
                UserImageUrl = "https://pbs.twimg.com/profile_images/897943933673627649/jplKYFXu_400x400.jpg",
                TweetImageAttachmentUrl = "https://pbs.twimg.com/media/DH0pK5bXcAEQgyG.jpg"
            });
        }
    }
}
