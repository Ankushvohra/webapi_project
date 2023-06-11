using FetchingApI.Models;
using FetchingApI.Repository.Irepository;

namespace FetchingApI.Repository
{
    public class NationalParkrepo:repository<NationalPark>,InationalPark
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NationalParkrepo(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
