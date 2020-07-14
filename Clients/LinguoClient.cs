using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Linguo
{
    public partial class LinguoClient
    {
        private readonly HttpClient _httpClient;

        public List<string> SupportedLanguges { get; }

        public LinguoClient(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException("ApiKey can not be empty");
            }

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            _httpClient.BaseAddress = new Uri("https://linguoapis.azurewebsites.net");

            SupportedLanguges = _httpClient.GetAsync<List<string>>("/api/v1/SupportedLanguges").Result;
        }

        public LinguoClient(HttpClient httpClient, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException("ApiKey can not be empty");
            }

            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            _httpClient.BaseAddress = new Uri("https://linguoapis.azurewebsites.net");

            SupportedLanguges = this._httpClient.GetAsync<List<string>>("/api/v1/SupportedLanguges").Result;
        }
    }
}
