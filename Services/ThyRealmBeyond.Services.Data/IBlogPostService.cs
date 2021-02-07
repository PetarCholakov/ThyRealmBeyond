namespace ThyRealmBeyond.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ThyRealmBeyond.Data.Models;

    public interface IBlogPostService
    {
        Task<int> CreateAsync(string title, string content, string userId);

        Task<int> UpdateAsync(int id, string title, string content);

        Task<int> DeleteAsync(int id);

        Task<T> GetByIdAsync<T>(int? id);

        IEnumerable<T> GetAll<T>();

        T GetByTitle<T>(string title);

        bool CheckBlogPostExist(int id);
    }
}
