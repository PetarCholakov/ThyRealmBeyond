namespace ThyRealmBeyond.Web.ViewModels.Administration.BlogPosts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class BlogPostEditInputModel : IMapTo<BlogPost>, IMapFrom<BlogPost>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Html)]
        public string PreviewContent { get; set; }

        [Required]
        [DataType(DataType.Html)]
        [MinLength(200, ErrorMessage = "Content must be at least 200 characters long.")]
        public string Content { get; set; }

        public string ImageUrl { get; set; }
    }
}
