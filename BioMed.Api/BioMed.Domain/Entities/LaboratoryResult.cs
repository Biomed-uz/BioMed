namespace BioMed.Domain.Entities
{
    public class LaboratoryResult : EntityBase
    {
        public string? Result { get; set; }
        public DateTime? Date { get; set; }

        public int AnalysisTypeId { get; set; }
        public AnalysisType? AnalysisType { get; set; }

        public virtual ICollection<Treatment>? Treatments { get; set;}
    }
}
