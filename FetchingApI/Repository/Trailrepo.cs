using FetchingApI.Repository.Irepository;

namespace FetchingApI.Repository
{
    public class Trailrepo:repository<Trailrepo>,Itrail
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Trailrepo(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
