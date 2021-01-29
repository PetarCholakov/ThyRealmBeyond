namespace ThyRealmBeyond.Web.ViewModels.Home
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;
    using ThyRealmBeyond.Data.Models;
    using ThyRealmBeyond.Services.Mapping;

    public class IndexBlogPostViewModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PreviewContent
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.Content, @"<[^>]+>", string.Empty));
                return content.Length > 300
                        ? content.Substring(0, 300) + "..."
                        : content;
            }
        }

        public string Url => $"/{this.Title.Replace(' ', '-')}";

        public DateTime CreatedOn { get; set; }
    }
}
