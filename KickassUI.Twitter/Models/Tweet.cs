using System;
namespace KickassUI.Twitter.Models
{
    public class Tweet
    {
        public string Username { get; set; }
        public string UserFullName { get; set; }
        public string PostDate { get; set; }
        public string UserImageUrl { get; set; }
        public string TweetText { get; set; }
        public string TweetImageAttachmentUrl { get; set; }
    }
}
