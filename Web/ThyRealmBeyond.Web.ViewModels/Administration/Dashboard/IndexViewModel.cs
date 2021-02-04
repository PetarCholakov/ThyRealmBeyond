namespace ThyRealmBeyond.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;

    using ThyRealmBeyond.Web.ViewModels.Administration.BlogPosts;

    public class IndexViewModel
    {
        public IEnumerable<BlogPostViewModel> BlogPosts { get; set; }
    }
}
