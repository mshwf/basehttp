using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GET.PKI.Base.ServiceInvoker
{
    internal class BaseHttpService
    {
        public BaseHttpService(HttpClient _httpClient)
        {
            _client = _httpClient;
        }

        private readonly HttpClient _client;

        internal async Task<TResponse> GetAsync<TResponse>(HttpGetRequest request)
        {
            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{request.Url}?{request.QueryString}");

                request.Headers.ForEach(kv =>
                {
                    requestMessage.Headers.Add(kv.Key, kv.Value);
                });
                var response = await _client.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    if (string.IsNullOrWhiteSpace(responseContent))
                        HandleNotOkResponse(response);
                }
                var result = JsonConvert.DeserializeObject<TResponse>(responseContent);
                return result;
            }
            catch
            {
                throw;
            }
        }

        internal async Task<TResponse> HttpPostAsync<TResponse>(HttpPostRequest request)
        {
            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, request.Url)
                {
                    Content = new StringContent(request.Body)
                };
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);

                request.Headers.ForEach(kv =>
                {
                    requestMessage.Headers.Add(kv.Key, kv.Value);
                });

                var response = await _client.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    if (string.IsNullOrWhiteSpace(responseContent))
                        HandleNotOkResponse(response);
                }
                var result = JsonConvert.DeserializeObject<TResponse>(responseContent);
                return result;
            }
            catch
            {
                throw;
            }
        }

        internal async Task<TResponse> HttpDeleteAsync<TResponse>(HttpDeleteRequest request)
        {
            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, request.Url);

                request.Headers.ForEach(kv =>
                {
                    _client.DefaultRequestHeaders.Remove(kv.Key); // keep headers updated
                    _client.DefaultRequestHeaders.Add(kv.Key, kv.Value);
                });

                var response = await _client.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    if (string.IsNullOrWhiteSpace(responseContent))
                        HandleNotOkResponse(response);
                }
                var result = JsonConvert.DeserializeObject<TResponse>(responseContent);
                return result;
            }
            catch
            {
                throw;
            }
        }
        private void HandleNotOkResponse(HttpResponseMessage response)
        {
            throw new Exception(response.ReasonPhrase);
        }
    }
}