namespace MiddleAPI.Helpers
{
    public static class AppSettingUtil
    {
        public static string ServiceBusNamespace => Get("ServiceBusNamespace");
        public static string MiddleApiConnectionString => Get("MiddleApiConnectionString");
        public static string IdentityServerEndpoint => Get("IdentityServerEndpoint");
        public static string Get(string key) => ConfigUtil.Instance.GetAppSetting(key);

    }
}
