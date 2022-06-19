using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GET.Spooler.Base
{
    internal class BaseHttpService20SecTimeout : IBaseHttpService
    {
        static BaseHttpService20SecTimeout()
        {
            if (_client == null)
            {
                _client = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(20)
                };
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public BaseHttpService20SecTimeout(string serviceName, bool acceptOnlyOkResponse, HttpClientOptions httpClientOptions)
        {
            ServiceName = serviceName;
            _acceptOnlyOkResponse = acceptOnlyOkResponse;
            _httpClientOptions = httpClientOptions;
        }

        private static readonly HttpClient _client;
        private readonly bool _acceptOnlyOkResponse;
        private readonly HttpClientOptions _httpClientOptions;

        public string ServiceName { get; }

        public async Task<TResponse> HttpGetAsync<TResponse>(HttpGetRequest request)
        {
            try
            {
                var requestUri = $"{request.Url}?{request.QueryString}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);

                request.Headers.ForEach(kv =>
                {
                    requestMessage.Headers.Add(kv.Key, kv.Value);
                });
                HttpResponseMessage response = await SendRequest(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                TResponse result = Deserialize<TResponse>(responseContent);
                return result;
            }
            catch
            {
                throw;
            }
        }


        public async Task<TResponse> HttpPostAsync<TResponse>(HttpPostRequest request)
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

                HttpResponseMessage response = await SendRequest(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                TResponse result = Deserialize<TResponse>(responseContent);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TResponse> HttpPutAsync<TResponse>(HttpPutRequest request)
        {
            try
            {
                var requestUri = $"{request.Url}?{request.QueryString}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri)
                {
                    Content = new StringContent(request.Body)
                };
                requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);

                request.Headers.ForEach(kv =>
                {
                    requestMessage.Headers.Add(kv.Key, kv.Value);
                });

                HttpResponseMessage response = await SendRequest(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                TResponse result = Deserialize<TResponse>(responseContent);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TResponse> HttpDeleteAsync<TResponse>(HttpDeleteRequest request)
        {
            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, request.Url);

                request.Headers.ForEach(kv =>
                {
                    _client.DefaultRequestHeaders.Remove(kv.Key); // keep headers updated
                    _client.DefaultRequestHeaders.Add(kv.Key, kv.Value);
                });

                HttpResponseMessage response = await SendRequest(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                TResponse result = Deserialize<TResponse>(responseContent);
                return result;
            }
            catch
            {
                throw;
            }
        }

        private async Task<HttpResponseMessage> SendRequest(HttpRequestMessage requestMessage)
        {
            try
            {
                // _client.Timeout = _httpClientOptions.TimeOut;
                var response = await _client.SendAsync(requestMessage);
                if (response.StatusCode != System.Net.HttpStatusCode.OK && _acceptOnlyOkResponse)
                {
                    throw new NetworkException($"{ServiceName} responded with {response.ReasonPhrase} ({(int)response.StatusCode}).", ServiceName);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new NetworkException($"The {ServiceName} is unreachable.", ServiceName, ex);
            }
        }

        private TResponse Deserialize<TResponse>(string responseContent)
        {
            try
            {
                return JSON.Deserialize<TResponse>(responseContent);
            }
            catch (Exception ex)
            {
                throw new ResponseDeserializationException($"The Response string from service: '{ServiceName}' couldn't be deserialized to the target type. See the inner exception for more details.", responseContent, ServiceName, ex);
            }
        }
    }
}