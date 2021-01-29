namespace ThyRealmBeyond.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ThyRealmBeyond.Data.Common.Models;
    using ThyRealmBeyond.Data.Models.Enums;

    public class Weakness : BaseDeletableModel<int>
    {
        public TypeOfWeakness Type { get; set; }

        public string Description { get; set; }

        public int Points { get; set; }
    }
}
