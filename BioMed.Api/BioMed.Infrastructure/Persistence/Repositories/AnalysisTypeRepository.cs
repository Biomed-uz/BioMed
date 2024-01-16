using BioMed.Domain.Entities;
using BioMed.Domain.Interfaces.Repositories;

namespace BioMed.Infrastructure.Persistence.Repositories
{
    public class AnalysisTypeRepository : RepositoryBase<AnalysisType>, IAnalysisTypeRepository
    {
        public AnalysisTypeRepository(BioMedDbContext context) : base(context)
        {
        }
    }
}
