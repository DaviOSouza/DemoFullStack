namespace FullStack.WebDemo.Services
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IConfiguration config)
        {

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(config["BaseUrl"]);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public async Task<T> GetAsyncByPage<T>(string url, int pageSize, int pageNumber, string nome = null)
        {
            string query = $"{url}?pageSize={pageSize}&pageNumber={pageNumber}";
            if (nome != null)
                query += $"&nome={nome}";

            HttpResponseMessage response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseBody);
        }

        public async Task PostAsync<TRequest>(string url, TRequest data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
           
        }

        public async Task PutAsync<TRequest>(string url, TRequest data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

        }

        public async Task DeleteAsync<TRequest>(string url)
        {
           
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

        }

       }

}
