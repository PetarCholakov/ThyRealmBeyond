namespace ThyRealmBeyond.Web.ViewModels.Administration.PersonalInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class PersonalInfoEditInputModel : IMapFrom<PersonalInfo>, IMapTo<PersonalInfo>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ImageUrl { get; set; }
    }
}
