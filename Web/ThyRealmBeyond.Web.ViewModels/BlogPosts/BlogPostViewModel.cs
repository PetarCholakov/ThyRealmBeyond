﻿namespace ThyRealmBeyond.Web.ViewModels.BlogPosts
{
    using System;

    using Ganss.XSS;
    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class BlogPostViewModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }
    }
}
