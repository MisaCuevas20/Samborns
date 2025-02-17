
using Newtonsoft.Json;
using WebMVC_Samborns.Models.Entities;

namespace WebMVC_Samborns.Services
{
    public class AreaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5164/api/Areas";

        public AreaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Area>> GetAreasAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Area>>(data) ?? new List<Area>();
        }

        public async Task<Area?> GetAreaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
            if (!response.IsSuccessStatusCode) return null;

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Area>(data);
        }

        public async Task<bool> CreateAreaAsync(Area area)
        {
            var content = new StringContent(JsonConvert.SerializeObject(area), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_baseUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAreaAsync(Area area)
        {
            var content = new StringContent(JsonConvert.SerializeObject(area), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/{area.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAreaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
