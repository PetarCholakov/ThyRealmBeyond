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
        [MinLength(200, ErrorMessage = "Content must be at least 200 characters long.")]
        public string Content { get; set; }
    }
}
