namespace ThyRealmBeyond.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ThyRealmBeyond.Data.Common.Models;

    public class BlogPost : BaseModel<int>
    {
        public string Title { get; set; }

        [MinLength(200, ErrorMessage = "Content must be at least 200 characters long.")]
        public string Content { get; set; }

        public string PreviewContent => this.Content.Substring(0, 200);

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
