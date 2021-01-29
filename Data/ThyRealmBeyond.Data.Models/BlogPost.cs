namespace ThyRealmBeyond.Data.Models
{
    using System.Collections.Generic;

    using ThyRealmBeyond.Data.Common.Models;

    public class BlogPost : BaseModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string PreviewContent => this.Content.Substring(0, 200);

        public virtual ApplicationUser Author { get; set; }
    }
}
