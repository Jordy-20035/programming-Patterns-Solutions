namespace Patterns.Ex01
{
    public interface ISocialNetworkClient
    {
        SocialNetworkUser[] GetSubscribers(string userName);
    }
}
