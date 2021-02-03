namespace ThyRealmBeyond.Web.ViewModels.Administration.BlogPosts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class BlogPostEditInputModel : IMapTo<BlogPost>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
