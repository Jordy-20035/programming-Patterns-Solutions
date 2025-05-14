namespace Patterns.Ex01
{
    public class TwitterClientAdapter : ISocialNetworkClient
    {
        private readonly TwitterClient _twitterClient;

        public TwitterClientAdapter()
        {
            _twitterClient = new TwitterClient();
        }

        public SocialNetworkUser[] GetSubscribers(string userName)
        {
            var twitterUsers = _twitterClient.GetFollowers(userName);
            var result = new SocialNetworkUser[twitterUsers.Length];
            for (int i = 0; i < twitterUsers.Length; i++)
            {
                result[i] = new SocialNetworkUser { UserName = twitterUsers[i] };
            }
            return result;
        }
    }
}
