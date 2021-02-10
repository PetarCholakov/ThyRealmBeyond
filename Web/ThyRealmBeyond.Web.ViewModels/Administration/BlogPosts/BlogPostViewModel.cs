namespace ThyRealmBeyond.Web.ViewModels.Administration.BlogPosts
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

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string PreviewContent { get; set; }

        public string SanitizedPreviewContent => new HtmlSanitizer().Sanitize(this.PreviewContent);

        public DateTime CreatedOn { get; set; }

        public bool  IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string UserId { get; set; }
    }
}
