namespace ThyRealmBeyond.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ThyRealmBeyond.Data.Common.Models;

    public class BlogPost : BaseModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
