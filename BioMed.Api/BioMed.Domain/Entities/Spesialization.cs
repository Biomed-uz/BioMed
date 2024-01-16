namespace BioMed.Domain.Entities
{
    public class Spesialization : EntityBase
    {
        public string? Name { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
    }
}
