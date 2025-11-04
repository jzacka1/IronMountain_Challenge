using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Mountain_Coding_Challenge.Services
{
    public class NlpClient : INlpClient
    {
        private readonly HttpClient _client;

        public NlpClient()
        {
            _client = new HttpClient();
        }

        public NlpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<dynamic> ParseQuery(string query)
        {
            var payload = new { query };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("http://localhost:8000/parse", content);
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<dynamic>(result).filters;
        }
    }
}
