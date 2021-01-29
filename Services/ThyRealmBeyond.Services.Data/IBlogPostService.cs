namespace ThyRealmBeyond.Services.Data
{
    using System.Collections.Generic;

    public interface IBlogPostService
    {
        IEnumerable<T> GetAll<T>(int? count);

        T GetByTiTle<T>(string title); 
    }
}
