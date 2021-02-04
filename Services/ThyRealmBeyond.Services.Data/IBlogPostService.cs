namespace ThyRealmBeyond.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ThyRealmBeyond.Data.Models;

    public interface IBlogPostService
    {
        Task<int> CreateAsync(string title, string content, string userId);

        IEnumerable<T> GetAll<T>();

        T GetByTitle<T>(string title);

        Task<T> GetByIdAsync<T>(int? id);

        Task<int> UpdateAsync(int id, string title, string content);

        bool CheckBlogPostExist(int id);
    }
}
