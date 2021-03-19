using DangKe.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DangKe.Web
{
    /// <summary>
    /// Http客户端
    /// </summary>
    public class DakHttpClient
    {
        /// <summary>
        /// GET请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<TResult> GetAsync<TResult>(string requestUri, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            using (var client = new HttpClient())
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                var str = await client.GetStringAsync(requestUri);

                return JsonHelper.FromJson<TResult>(str);
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
        public async Task<TResult> PostAsync<TResult>(string requestUri, object content, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            using (var client = new HttpClient())
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                var strContent = new StringContent(JsonHelper.ToJson(content), Encoding.UTF8, MediaType.Json);

                using (var response = await client.PostAsync(requestUri, strContent))
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonHelper.FromJson<TResult>(result);
                }
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
        public async Task<TResult> PutAsync<TResult>(string requestUri, object content, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            using (var client = new HttpClient())
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                var strContent = new StringContent(JsonHelper.ToJson(content), Encoding.UTF8, MediaType.Json);

                using (var response = await client.PutAsync(requestUri, strContent))
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonHelper.FromJson<TResult>(result);
                }
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
        public async Task<TResult> DeleteAsync<TResult>(string requestUri, IEnumerable<KeyValuePair<string, string>> headers = null)
            where TResult : class
        {
            using (var client = new HttpClient())
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                using (var response = await client.DeleteAsync(requestUri))
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonHelper.FromJson<TResult>(result);
                }
            }
        }
    }
}