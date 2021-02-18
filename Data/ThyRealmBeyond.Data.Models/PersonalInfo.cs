namespace ThyRealmBeyond.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ThyRealmBeyond.Data.Common.Models;

    public class PersonalInfo : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
