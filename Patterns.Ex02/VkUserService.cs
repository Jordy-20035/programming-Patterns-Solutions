namespace Patterns.Ex02
{
    public class VkUserService : UserServiceBase
    {
        protected override string ParseUserId(string pageUrl)
        {
            // Используем существующий метод Parse
            return Parse(pageUrl);
        }

        protected override string GetUserName(string userId)
        {
            return GetName(userId);
        }

        protected override object[] GetSubscribers(string userId)
        {
            return GetFriendsById(userId);
        }

        protected override UserInfo[] ConvertSubscribersToUserInfo(object[] subscribers)
        {
            // Приводим к VkUser[]
            var vkUsers = subscribers as VkUser[] ?? new VkUser[0];
            return ConvertToUserInfo(vkUsers);
        }

        // Старые методы оставляем без изменений

        private string GetName(string userId)
        {
            return "NAME";
        }

        private VkUser[] GetFriendsById(string userId)
        {
            return new VkUser[0];
        }

        private string Parse(string pageUrl)
        {
            return "USER_ID";
        }

        private UserInfo[] ConvertToUserInfo(VkUser[] friends)
        {
            return new UserInfo[0];
        }
    }
}
