using Lantern.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lantern.Utils
{
    /// <summary>
    /// Http客户端
    /// </summary>
    public static class HttpHelper
    {
        private static readonly HttpClient client = new HttpClient();

        static HttpHelper()
        {
        }

        private static void AddHeaders(IEnumerable<KeyValuePair<string, string>> headers)
        {
            foreach (var header in headers)
            {
                if (!client.DefaultRequestHeaders.Contains(header.Key))
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }

        /// <summary>
        /// GET请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public static async Task<TResult> GetAsync<TResult>(string requestUri, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            AddHeaders(headers);

            var str = await client.GetStringAsync(requestUri);

            return JsonHelper.FromJson<TResult>(str);
        }

        /// <summary>
        /// POST请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<TResult> PostAsync<TResult>(string requestUri, object content, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            AddHeaders(headers);

            var strContent = new StringContent(JsonHelper.ToJson(content), Encoding.UTF8, MediaType.Json);

            using (var response = await client.PostAsync(requestUri, strContent))
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonHelper.FromJson<TResult>(result);
            }
        }

        /// <summary>
        /// PUT请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<TResult> PutAsync<TResult>(string requestUri, object content, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            AddHeaders(headers);

            var strContent = new StringContent(JsonHelper.ToJson(content), Encoding.UTF8, MediaType.Json);

            using (var response = await client.PutAsync(requestUri, strContent))
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonHelper.FromJson<TResult>(result);
            }
        }

        /// <summary>
        /// DELETE请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<TResult> DeleteAsync<TResult>(string requestUri, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            AddHeaders(headers);

            using (var response = await client.DeleteAsync(requestUri))
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonHelper.FromJson<TResult>(result);
            }
        }

        /// <summary>
        /// POST请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<TResult> PostAsync<TResult>(string requestUri, string[] filePaths, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            var content = new MultipartFormDataContent();

            foreach (var path in filePaths)
            {
                content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(path)), "file", "123.png");
            }

            using (var response = await client.PostAsync(requestUri, content))
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonHelper.FromJson<TResult>(result);
            }
        }
    }
}