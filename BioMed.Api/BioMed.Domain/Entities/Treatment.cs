namespace BioMed.Domain.Entities
{
    public class Treatment : EntityBase
    {
        public string? Prescription { get; set; }

        public int VisitId { get; set; }
        public Visit? Visit { get; set; }
        public int LaboratoryResultId { get; set; }
        public LaboratoryResult? LaboratoryResult { get; set; }
        public int DiseaseId { get; set; }
        public Disease? Disease { get; set; }
    }
}
