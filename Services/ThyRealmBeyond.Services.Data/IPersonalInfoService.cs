namespace ThyRealmBeyond.Services.Data
{
    using System.Threading.Tasks;

    public interface IPersonalInfoService
    {
        T GetPersonalInfo<T>();

        bool PersonalInfoExists();

        Task<int> CreateAsync(string title, string content, string imageUrl, string email);

        Task<int> EditAsync(string title, string content, string imageUrl, string email);
    }
}
