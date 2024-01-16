using BioMed.Domain.Entities;
using BioMed.Domain.Interfaces.Repositories;

namespace BioMed.Infrastructure.Persistence.Repositories
{
    public class LaboratoryResultRepository : RepositoryBase<LaboratoryResult>, ILaboratoryResultRepository
    {
        public LaboratoryResultRepository(BioMedDbContext context) : base(context)
        {
        }
    }
}
