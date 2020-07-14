using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Linguo
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };


        internal async static ValueTask<T> PostAsync<T>(this HttpClient httpClient, string url, object obj, CancellationToken cancellationToken = default)
        {
            try
            {
                Uri uri = new Uri(url);

                HttpContent request = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

                HttpResponseMessage res = await httpClient.PostAsync(uri, request, cancellationToken);

                if (res.StatusCode == System.Net.HttpStatusCode.OK || res.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return await JsonSerializer.DeserializeAsync<T>(await res.Content.ReadAsStreamAsync(), _options, cancellationToken);
                }

                throw new Exception(JsonSerializer.Serialize(await res.Content.ReadAsStringAsync(), _options));
            }
            catch
            {
                throw;
            }
        }

        internal async static ValueTask<byte[]> PostAsync(this HttpClient httpClient, string url, object obj, CancellationToken cancellationToken = default)
        {
            try
            {
                Uri uri = new Uri(url);

                HttpContent request = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

                HttpResponseMessage res = await httpClient.PostAsync(uri, request, cancellationToken);

                if (res.StatusCode == System.Net.HttpStatusCode.OK || res.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return await res.Content.ReadAsByteArrayAsync();
                }

                throw new Exception(JsonSerializer.Serialize(await res.Content.ReadAsStringAsync(), _options));
            }
            catch
            {
                throw;
            }
        }

        internal async static ValueTask<T> PostAsMultipartAsync<T>(this HttpClient httpClient, string url, MultipartFormDataContent obj, CancellationToken cancellationToken = default)
        {
            try
            {
                Uri uri = new Uri(url);

                HttpResponseMessage res = await httpClient.PostAsync(uri, obj, cancellationToken);

                if (res.StatusCode == System.Net.HttpStatusCode.OK || res.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return await JsonSerializer.DeserializeAsync<T>(await res.Content.ReadAsStreamAsync(), _options, cancellationToken);
                }

                throw new Exception(JsonSerializer.Serialize(await res.Content.ReadAsStringAsync(), _options));
            }
            catch
            {
                throw;
            }
        }

        internal async static ValueTask<byte[]> PostAsMultipartAsync(this HttpClient httpClient, string url, MultipartFormDataContent obj, CancellationToken cancellationToken = default)
        {
            try
            {
                Uri uri = new Uri(url);

                HttpResponseMessage res = await httpClient.PostAsync(uri, obj, cancellationToken);

                if (res.StatusCode == System.Net.HttpStatusCode.OK || res.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return await res.Content.ReadAsByteArrayAsync();
                }

                throw new Exception(JsonSerializer.Serialize(await res.Content.ReadAsStringAsync(), _options));
            }
            catch
            {
                throw;
            }
        }

        internal async static ValueTask<T> GetAsync<T>(this HttpClient httpClient, string url, CancellationToken cancellationToken = default)
        {
            try
            {
                Uri uri = new Uri(url);

                HttpResponseMessage res = await httpClient.GetAsync(uri, cancellationToken);

                if (res.StatusCode == System.Net.HttpStatusCode.OK || res.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    if (typeof(T) == typeof(byte[]))
                    {

                    }

                    return await JsonSerializer.DeserializeAsync<T>(await res.Content.ReadAsStreamAsync(), _options, cancellationToken);
                }

                throw new Exception(JsonSerializer.Serialize(await res.Content.ReadAsStringAsync(), _options));
            }
            catch
            {
                throw;
            }
        }
    }
}
