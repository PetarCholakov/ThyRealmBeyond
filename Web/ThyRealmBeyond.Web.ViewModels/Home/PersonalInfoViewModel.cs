namespace ThyRealmBeyond.Web.ViewModels.PersonalInfo
{
    using System;

    using Ganss.XSS;
    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class PersonalInfoViewModel : IMapFrom<PersonalInfo>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string ImageUrl { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
