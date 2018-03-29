using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Inspark.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get{return CrossSettings.Current;}
        }

        private const string UserNameKey = "username_key";
        private static readonly string UserNameDefault = string.Empty;
        public static string UserName
        {
            get { return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault); }
            set { AppSettings.AddOrUpdateValue(UserNameKey, value); }
        }
        private const string UserPasswordKey = "userpassword_key";
        private static readonly string UserPasswordDefault = string.Empty;
        public static string UserPassword
        {
            get { return AppSettings.GetValueOrDefault(UserPasswordKey, UserPasswordDefault); }
            set { AppSettings.AddOrUpdateValue(UserPasswordKey, value); }
        }
        
        private const string AccessTokenKey = "AccessToken_key";
        private static readonly string AccessTokenDefault = string.Empty;
        public static string AccessToken
        {
            get { return AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault); }
            set { AppSettings.AddOrUpdateValue(AccessTokenKey, value); }
        }

        private const string KeepLoggedInKey = "KeepLoggedIn_key";
        private static readonly bool KeepLoggedInDefault = false;
        public static bool KeepLoggedIn
        {
            get { return AppSettings.GetValueOrDefault(KeepLoggedInKey, KeepLoggedInDefault); }
            set { AppSettings.AddOrUpdateValue(KeepLoggedInKey, value); }
        }
    }
}