namespace BioMed.Domain.ResourceParameters
{
    public class DoctorResourceParameters : ResourceParametersBase
    {
        public int SpesializationId { get; set; }
        public decimal? PricePerVisit { get; set; }
        public decimal? PricePerVisitLessThan { get; set; }
        public decimal? PricePerVisitGreaterThan { get; set; }
        public override string OrderBy { get; set; } = "fullname";
    }
}
