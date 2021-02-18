namespace ThyRealmBeyond.Web.ViewModels.Administration.PersonalInfo
{
    using System.ComponentModel.DataAnnotations;

    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class PersonalInfoCreateInputModel : IMapTo<PersonalInfo>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
