namespace Patterns.Ex01
{
    public class InstagramClientAdapter : ISocialNetworkClient
    {
        private readonly InstagramClient _instagramClient;

        public InstagramClientAdapter()
        {
            _instagramClient = new InstagramClient();
        }

        public SocialNetworkUser[] GetSubscribers(string userName)
        {
            var instagramUsers = _instagramClient.GetFollowers(userName);
            var result = new SocialNetworkUser[instagramUsers.Length];
            for (int i = 0; i < instagramUsers.Length; i++)
            {
                result[i] = new SocialNetworkUser { UserName = instagramUsers[i] };
            }
            return result;
        }
    }
}
