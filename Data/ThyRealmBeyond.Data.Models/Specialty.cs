namespace ThyRealmBeyond.Data.Models
{
    using ThyRealmBeyond.Data.Common.Models;
    using ThyRealmBeyond.Data.Models.Enums;

    public class Specialty : BaseDeletableModel<int>
    {
        public TypeOfSpecialty Type { get; set; }

        public string Description { get; set; }

        public int Points { get; set; }
    }
}
