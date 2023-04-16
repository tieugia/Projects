using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MiddleAPI.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class IdentityServerResponse
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
    }
}
