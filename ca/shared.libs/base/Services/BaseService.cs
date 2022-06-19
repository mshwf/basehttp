using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;

namespace GET.PKI.Base.ServiceInvoker
{
    [DebuggerDisplay("{BaseUri}")]
    public abstract class BaseService
    {
        readonly BaseHttpService httpService;
        protected JwtProvider JwtProvider { get; set; }
        protected BaseService(HttpClient client)
        {
            if (string.IsNullOrWhiteSpace(client.BaseAddress.ToString()))
                throw new ArgumentNullException($"{nameof(client.BaseAddress)}", $"Service URL of {GetType().Name} cannot be resolved");

            httpService = new BaseHttpService(client);
        }

        protected string BaseUri { get; }

        public async Task<TResponse> GetAsync<TResponse>(BaseGetRequest request)
        {
            try
            {
                var uri = BaseUri + request.Route;
                var result = await httpService.GetAsync<TResponse>(new HttpGetRequest(uri, request.QueryParams, await CreateHeaders(request.Headers)));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TResponse> PostAsync<TResponse>(BasePostRequest request)
        {
            try
            {
                var uri = BaseUri + request.Route;
                var result = await httpService.HttpPostAsync<TResponse>(new HttpPostRequest(uri, request.Body, request.ContentType, await CreateHeaders(request.Headers)));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TResponse> DeleteAsync<TResponse>(BaseDeleteRequest request)
        {
            try
            {
                var uri = BaseUri + request.Route;
                var result = await httpService.HttpDeleteAsync<TResponse>(new HttpDeleteRequest(uri, request.QueryParams, await CreateHeaders(request.Headers)));
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
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