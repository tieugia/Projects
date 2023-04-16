using Microsoft.Extensions.Configuration;
using System;

namespace MiddleAPI.Helpers
{
    public static class ConfigUtilInitializer
    {
        public static void Init(IConfiguration configurationRoot)
        {
            ConfigUtil.Instance.Init(configurationRoot);
        }
        public static void InitForAzureFunction(string appPrefixWithSlash = null)
        {
            var envName = Environment.GetEnvironmentVariable("ENVIRONMENT");
            const string SharePrefix = "Share/";
            var azureAppConfigurationConnStr = Environment.GetEnvironmentVariable("AzureAppConfigurationConnStr");
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddAzureAppConfiguration(options =>
            {
                options
                    .Connect(azureAppConfigurationConnStr)
                    .Select($"{SharePrefix}*").TrimKeyPrefix(SharePrefix)
                    .Select($"{SharePrefix}*", envName).TrimKeyPrefix(SharePrefix);
                if (!string.IsNullOrEmpty(appPrefixWithSlash))
                {
                    options.Select($"{appPrefixWithSlash}*").TrimKeyPrefix(appPrefixWithSlash)
                    .Select($"{appPrefixWithSlash}*", envName).TrimKeyPrefix(appPrefixWithSlash);
                }
            });

            configBuilder.AddEnvironmentVariables();
            var configRoot = configBuilder.Build();

            Init(configRoot);
        }
    }
}
