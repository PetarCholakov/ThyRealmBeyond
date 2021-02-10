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
        public string Content { get; set; }

        public string PreviewContent { get; set; }
    }
}
