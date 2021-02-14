namespace ThyRealmBeyond.Web.ViewModels.Administration.BlogPosts
{
    using System.ComponentModel.DataAnnotations;

    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class BlogPostCreateInputModel : IMapTo<BlogPost>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string PreviewContent { get; set; }
    }
}
