namespace BioMed.Domain.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        public ISpesializationRepository Spesialization { get; }
        public IDepartmentRepository Department { get; }
        public IDoctorRepository Doctor { get; }
        public IPatientRepository Patient { get; }
        public IVisitRepository Visit {  get; }
        public IPaymentRepository Payment { get; }
        public IAnalysisTypeRepository AnalysisType { get; }
        public ILaboratoryResultRepository LaboratoryResult { get; }
        public IDiseaseCategoryRepository DiseaseCategory { get; }
        public IDiseaseRepository Disease { get; }
        public ITreatmentRepository Treatment { get; }

        public int SaveChanges();
    }
}
