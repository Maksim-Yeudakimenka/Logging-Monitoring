using MvcMusicStore.Models;
using NLog;

namespace MvcMusicStore.Infrastructure
{
    public static class LoggerExtensions
    {
        public static ILogger LoggedIn(this ILogger logger, ApplicationUser user)
        {
            logger.Info($"User \"{user.UserName}\" is logged in");
            return logger;
        }

        public static ILogger LoggedOut(this ILogger logger)
        {
            logger.Info("User is logged out");
            return logger;
        }

        public static ILogger PageOpened(this ILogger logger, string controllerName, string actionName)
        {
            logger.Debug($"Page \"{controllerName}/{actionName}\" is opened");
            return logger;
        }

        public static ILogger ActionInvoked(this ILogger logger, string controllerName, string actionName)
        {
            logger.Debug($"Action \"{controllerName}/{actionName}\" is invoked");
            return logger;
        }
    }
}