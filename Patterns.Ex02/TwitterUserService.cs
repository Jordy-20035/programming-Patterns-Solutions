using System.Linq;
using System.Text.RegularExpressions;
using Patterns.Ex01.ExternalLibs.Twitter;

namespace Patterns.Ex02
{
    public class TwitterUserService : UserServiceBase
    {
        private readonly TwitterClient _client = new TwitterClient();

        protected override string ParseUserId(string pageUrl)
        {
            var regex = new Regex("twitter.com/(.*)");
            var match = regex.Match(pageUrl);
            return match.Groups[1].Value; // исправлено с Groups[0] на Groups[1]
        }

        protected override string GetUserName(string userId)
        {
            return userId; // В данном случае userId - это userName
        }

        protected override object[] GetSubscribers(string userId)
        {
            return _client.GetSubscribers(userId).Cast<object>().ToArray();
        }

        protected override UserInfo[] ConvertSubscribersToUserInfo(object[] subscribers)
        {
            var twitterUsers = subscribers.Cast<Patterns.Ex01.ExternalLibs.Twitter.TwitterUser>().ToArray();

            return twitterUsers.Select(tu => new UserInfo
            {
                UserId = tu.UserId.ToString(),
                Name = _client.GetUserNameById(tu.UserId)
            }).ToArray();
        }
    }
}
