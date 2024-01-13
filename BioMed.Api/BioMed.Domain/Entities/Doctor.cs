namespace BioMed.Domain.Entities
{
    public class Doctor : EntityBase
    {
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal PricePerVisit { get; set; }

        public int SpesializationId { get; set; }
        public Spesialization Spesialization { get; set; }

        public virtual ICollection<Visit>? Visits { get; set; }
    }
}
