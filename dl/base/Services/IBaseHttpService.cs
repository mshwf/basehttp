using System.Threading.Tasks;

namespace GET.Spooler.Base
{
    internal interface IBaseHttpService
    {
        string ServiceName { get; }

        Task<TResponse> HttpGetAsync<TResponse>(HttpGetRequest request);
        Task<TResponse> HttpDeleteAsync<TResponse>(HttpDeleteRequest request);
        Task<TResponse> HttpPostAsync<TResponse>(HttpPostRequest request);
        Task<TResponse> HttpPutAsync<TResponse>(HttpPutRequest request);
    }
}