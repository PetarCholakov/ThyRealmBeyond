namespace ThyRealmBeyond.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ThyRealmBeyond.Data.Common.Models;

    public class BlogPost : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

        [DataType(DataType.Html)]
        public string PreviewContent { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
