namespace ThyRealmBeyond.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogPostService
    {
        Task<int> CreateAsync(string title, string content, string userId);

        IEnumerable<T> GetAll<T>(int? count);

        T GetByTitle<T>(string title);

        T GetById<T>(int id);
    }
}
