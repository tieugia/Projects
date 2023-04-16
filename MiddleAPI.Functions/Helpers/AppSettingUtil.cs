namespace MiddleAPI.Helpers
{
    public static class AppSettingUtil
    {
        public static string ServiceBusNamespace => Get("ServiceBusNamespace");
        public static string MiddleApiConnectionString => Get("MiddleApiConnectionString");
        public static string IdentityServerEndpoint => Get("IdentityServerEndpoint");

        public static string Scope => Get("scope");
        public static string GrantType => Get("grant_type");
        public static string ClientSecret => Get("client_secret");
        public static string ClientId => Get("client_id");

        public static string Get(string key) => ConfigUtil.Instance.GetAppSetting(key);

    }
}
