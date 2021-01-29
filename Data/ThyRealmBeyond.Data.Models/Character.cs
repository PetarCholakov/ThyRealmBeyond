namespace ThyRealmBeyond.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ThyRealmBeyond.Data.Common.Models;
    using ThyRealmBeyond.Data.Models.Enums;

    public class Character : BaseDeletableModel<string>
    {
        public Character()
        {
            this.Weaknesses = new HashSet<Weakness>();
            this.Specialties = new HashSet<Specialty>();
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Nickname { get; set; }

        // Look
        public int Age { get; set; }

        public Origin Origin { get; set; }

        public Sex Sex { get; set; }

        public string Appearance { get; set; }

        // Skillset
        public int Strength { get; set; }

        public int Capability { get; set; }

        public int Confidence { get; set; }

        public int Perception { get; set; }

        public virtual ICollection<Weakness> Weaknesses { get; set; }

        public virtual ICollection<Specialty> Specialties { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
