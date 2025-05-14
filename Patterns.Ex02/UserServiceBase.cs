namespace Patterns.Ex02
{
    public abstract class UserServiceBase
    {
        /// <summary>
        /// Шаблонный метод - общий алгоритм получения UserInfo
        /// </summary>
        public UserInfo GetUserInfo(string pageUrl)
        {
            var userId = ParseUserId(pageUrl);
            var userName = GetUserName(userId);
            var subscribers = GetSubscribers(userId);
            var friends = ConvertSubscribersToUserInfo(subscribers);

            return new UserInfo
            {
                UserId = userId,
                Name = userName,
                Friends = friends
            };
        }

        // Абстрактные методы - детали реализации в наследниках

        protected abstract string ParseUserId(string pageUrl);

        protected abstract string GetUserName(string userId);

        protected abstract object[] GetSubscribers(string userId);

        protected abstract UserInfo[] ConvertSubscribersToUserInfo(object[] subscribers);
    }
}
