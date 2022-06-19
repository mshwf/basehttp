using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GET.PKI.Common.Utilities
{
    public static class HttpUtilities
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<bool> IsResponsiveUrl(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
