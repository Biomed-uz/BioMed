namespace BioMed.Domain.Entities
{
    public class AnalysisType : EntityBase
    {
        public string? Name { get; set; }

        public virtual ICollection<LaboratoryResult>? LabResults { get; set;}
    }
}
