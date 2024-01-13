namespace BioMed.Domain.Entities
{
    public class Department : EntityBase
    {
        public string? Name { get; set; }

        public virtual ICollection<Spesialization>? Spesializations { get;}
    }
}
