using System;
using System.Collections.Generic;

namespace Patterns.Ex01
{
    public class SubscriberViewer
    {
        private readonly Dictionary<SocialNetwork, ISocialNetworkClient> _clients;

        public SubscriberViewer()
        {
            _clients = new Dictionary<SocialNetwork, ISocialNetworkClient>
            {
                { SocialNetwork.Twitter, new TwitterClientAdapter() },
                { SocialNetwork.Instagram, new InstagramClientAdapter() }
            };
        }

        public SocialNetworkUser[] GetSubscribers(string userName, SocialNetwork networkType)
        {
            if (_clients.TryGetValue(networkType, out var client))
            {
                return client.GetSubscribers(userName);
            }
            throw new ArgumentException($"Unsupported social network: {networkType}");
        }
    }
}
