namespace BioMed.Domain.ResourceParameters
{
    public class TreatmentResourceParameters : ResourceParametersBase
    {
        public int VisitId { get; set; }
        public int LaboratoryResultId { get; set; }
        public int DiseaseId { get; set; }
        public override string OrderBy { get; set; } = "prescription";
    }
}
