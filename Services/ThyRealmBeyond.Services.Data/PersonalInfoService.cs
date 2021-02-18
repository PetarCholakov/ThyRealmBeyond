namespace ThyRealmBeyond.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ThyRealmBeyond.Data.Common.Repositories;
    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IDeletableEntityRepository<PersonalInfo> repository;

        public PersonalInfoService(IDeletableEntityRepository<PersonalInfo> repository)
        {
            this.repository = repository;
        }

        public T GetPersonalInfo<T>()
        {
            var personalInfoModel = this.repository.All().To<T>().FirstOrDefault();

            return personalInfoModel;
        }

        public async Task<int> CreateAsync(string title, string content, string imageUrl, string email)
        {
            var modelToCreate = new PersonalInfo()
            {
                Title = title,
                Content = content,
                ImageUrl = imageUrl,
                Email = email,
            };

            await this.repository.AddAsync(modelToCreate);
            await this.repository.SaveChangesAsync();

            return modelToCreate.Id;
        }

        public async Task<int> EditAsync(string title, string content, string imageUrl, string email)
        {
            var modelToEdit = this.repository.All().FirstOrDefault();

            modelToEdit.Title = title;
            modelToEdit.Content = content;
            modelToEdit.ImageUrl = imageUrl;
            modelToEdit.Email = email;

            this.repository.Update(modelToEdit);
            await this.repository.SaveChangesAsync();

            return modelToEdit.Id;
        }

        public bool PersonalInfoExists()
        {
            return this.repository.All().Any();
        }
    }
}
