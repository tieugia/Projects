using Microsoft.Extensions.Configuration;
using System;

namespace MiddleAPI.Helpers
{
    sealed class ConfigUtil
    {
        IConfiguration _configurationRoot;
        private Lazy<SystemConfig> _lzSystemConfig;

        private ConfigUtil() { }
        internal void Init(IConfiguration configurationRoot)
        {
            _configurationRoot = configurationRoot;

            _lzSystemConfig = new Lazy<SystemConfig>(() =>
            {
                var val = new SystemConfig();
                _configurationRoot.Bind(val);
                return val;
            });
        }
        public static ConfigUtil Instance { get; } = new ConfigUtil();

        public string GetAppSetting(string key)
        {
            if (_configurationRoot == null)
                throw new Exception($"{nameof(ConfigUtil)} is not initialized");
            return _configurationRoot[key];
        }

        public string GetConnectionString(string key)
        {
            if (_configurationRoot == null)
                throw new Exception($"{nameof(ConfigUtil)} is not initialized");
            return _configurationRoot.GetConnectionString(key);
        }
    }
    public class SystemConfig
    {
        public string ServiceBusNamespace { get; set; }
    }
}
