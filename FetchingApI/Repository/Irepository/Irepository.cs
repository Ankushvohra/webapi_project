namespace FetchingApI.Repository.Irepository
{
    public interface Irepository <T> where T : class
    {
        Task<T> GetAsync(string url, int id);
        Task<IEnumerable<T>> GetAllAsync(string url);
        Task <bool> CreateAsync(string url, T objecttocreate);
        Task<bool> UpdateAsync(string url, T objecttoupdate);
        Task<bool> deleteAsync(string url, int id);
    }
}
