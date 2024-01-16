namespace BioMed.Domain.Entities
{
    public class Disease : EntityBase
    {
        public string? Name { get; set; }
        public int DiseaseCategoryId { get; set; }
        public DiseaseCategory? DiseaseCategory { get; set; }

        public virtual ICollection<Treatment>? Treatments { get; set; }
    }
}
