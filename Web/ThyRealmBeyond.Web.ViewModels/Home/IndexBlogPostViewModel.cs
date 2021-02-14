namespace ThyRealmBeyond.Web.ViewModels.Home
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    using Ganss.XSS;
    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class IndexBlogPostViewModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PreviewContent { get; set; }

        public string SanitizedPreviewContent => new HtmlSanitizer().Sanitize(this.PreviewContent);

        public string Url => $"/{this.Title.Replace(' ', '-')}";

        public DateTime CreatedOn { get; set; }
    }
}
