using System;
using System.Net.Http;
using System.Collections.Generic;

namespace Linguo
{
    public partial class LinguoClient
    {
        private readonly HttpClient _httpClient;

        public IEnumerable<string> SupportedLanguges => _httpClient.GetAsync<IEnumerable<string>>("/api/v1/SupportedLanguges").Result;
     
        public LinguoClient(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            _httpClient.BaseAddress = new Uri("https://linguoapis.azurewebsites.net");
        }

        public LinguoClient(HttpClient httpClient, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            _httpClient.BaseAddress = new Uri("https://linguoapis.azurewebsites.net");
        }
    }
}
