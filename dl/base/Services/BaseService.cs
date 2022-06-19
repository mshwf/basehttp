using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GET.Spooler.Base
{
    public enum HttpClientTimeout
    {
        Default,
        _5Sec,
        _20Sec
    }
    public class ServiceOptions
    {
        /// <summary>
        /// Indicates whether to handle not OK (200) responses, 
        /// if set to true (default) means that only 200 responses are expected and deserialized, otherwise NetworkException is thrown.
        /// </summary>
        public bool AcceptOnlyOkResponse { get; set; }
        public HttpClientOptions HttpClientOptions { get; set; }
    }
    public class HttpClientOptions
    {
        public TimeSpan TimeOut { get; set; }
    }

    [DebuggerDisplay("{BaseUri}")]
    public abstract class BaseService
    {
        readonly IBaseHttpService httpService;
        protected JwtProvider JwtProvider { get; set; }
        //protected bool AcceptOnlyOkResponse { get; set; } = true;
        protected ServiceOptions ServiceOptions { get; set; } = new ServiceOptions
        {
            AcceptOnlyOkResponse = true,
            HttpClientOptions = new HttpClientOptions
            {
                TimeOut = TimeSpan.FromSeconds(100)
            }
        };

        protected BaseService(string baseUri, HttpClientTimeout timeout = HttpClientTimeout.Default)
        {
            if (string.IsNullOrWhiteSpace(baseUri))
                throw new ArgumentNullException($"{nameof(baseUri)}", $"Service URL of {GetType().Name} cannot be resolved");
            BaseUri = baseUri + (baseUri.EndsWith("/") ? "" : "/");

            httpService = timeout switch
            {
                HttpClientTimeout._20Sec => new BaseHttpService20SecTimeout(GetType().Name, ServiceOptions.AcceptOnlyOkResponse, ServiceOptions.HttpClientOptions),
                HttpClientTimeout._5Sec => new BaseHttpService5SecTimeout(GetType().Name, ServiceOptions.AcceptOnlyOkResponse, ServiceOptions.HttpClientOptions),
                _ => new BaseHttpService(GetType().Name, ServiceOptions.AcceptOnlyOkResponse, ServiceOptions.HttpClientOptions),
            };
        }

        protected string BaseUri { get; }

        protected async Task<TResponse> GetAsync<TResponse>(BaseGetRequest request)
        {
            try
            {
                var uri = BaseUri + request.Route;
                var result = await httpService.HttpGetAsync<TResponse>(new HttpGetRequest(uri, request.QueryParams, await CreateHeaders(request.Headers)));
                return result;
            }
            catch
            {
                throw;
            }
        }

        protected async Task<TResponse> PostAsync<TResponse>(BasePostRequest request)
        {
            try
            {
                var uri = BaseUri + request.Route;
                var result = await httpService.HttpPostAsync<TResponse>(new HttpPostRequest(uri, request.Body, request.ContentType, await CreateHeaders(request.Headers)));
                return result;
            }
            catch
            {
                throw;
            }
        }

        protected async Task<TResponse> PutAsync<TResponse>(BasePutRequest request)
        {
            try
            {
                var uri = BaseUri + request.Route;
                var result = await httpService.HttpPutAsync<TResponse>(new HttpPutRequest(uri, request.QueryParams, request.Body, request.ContentType, await CreateHeaders(request.Headers)));
                return result;
            }
            catch
            {
                throw;
            }
        }

        protected async Task<TResponse> DeleteAsync<TResponse>(BaseDeleteRequest request)
        {
            try
            {
                var uri = BaseUri + request.Route;
                var result = await httpService.HttpDeleteAsync<TResponse>(new HttpDeleteRequest(uri, request.QueryParams, await CreateHeaders(request.Headers)));
                return result;

            }
            catch
            {
                throw;
            }
        }

        private async Task<List<KeyValuePair<string, string>>> CreateHeaders(List<KeyValuePair<string, string>> headers)
        {
            headers = (headers?.Count > 0) ? headers : new List<KeyValuePair<string, string>>();
            var jwtToken = await GetAuthorizationToken();
            if (!string.IsNullOrEmpty(jwtToken))
                headers.Add(new KeyValuePair<string, string>("Authorization", $"Bearer {jwtToken}"));
            return headers;
        }
        private async Task<string> GetAuthorizationToken()
        {
            if (JwtProvider == null) return null;
            var Jwt = await JwtProvider.RefreshJwt();
            return Jwt;
        }
    }
}