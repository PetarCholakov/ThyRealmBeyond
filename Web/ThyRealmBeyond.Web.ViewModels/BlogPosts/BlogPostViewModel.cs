namespace ThyRealmBeyond.Web.ViewModels.BlogPosts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class BlogPostViewModel : IMapFrom<BlogPost>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
