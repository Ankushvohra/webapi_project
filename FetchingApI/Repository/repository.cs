using FetchingApI.Repository.Irepository;
using Newtonsoft.Json;
using System.Text;

namespace FetchingApI.Repository
{
    public class repository<T> : Irepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public repository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> CreateAsync(string url, T objecttocreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if (objecttocreate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objecttocreate), Encoding.UTF8, "application/Json");
            }
            var cilent = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await cilent.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }

        public async Task<bool> deleteAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + "/"+ id.ToString());
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var Jsonstring = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(Jsonstring);
            }
            return null;
        }

        public  async Task<T> GetAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + "/" + id.ToString());
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var Jsonstring = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(Jsonstring);
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string url, T objecttoupdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            if (objecttoupdate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objecttoupdate), Encoding.UTF8, "application/Json");
            }
            var cilent = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await cilent.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }
    }
}
