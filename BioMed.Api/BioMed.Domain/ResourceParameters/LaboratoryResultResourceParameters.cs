namespace BioMed.Domain.ResourceParameters
{
    public class LaboratoryResultResourceParameters : ResourceParametersBase
    {
        public int AnalysisTypeId { get; set; }
        public override string OrderBy { get; set; } = "name";

        protected override int MaxPageSize { get; set; } = 50;
    }
}
