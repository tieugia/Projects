using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MiddleAPI.Helpers
{
    public class Helper
    {
        public static async Task<T> GetObjectByUserIdAndVisitIdAsync<T>(string userId, int visitId, string token, string url) where T : class
        {
            using var _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(string.Format(url, userId, visitId));
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
