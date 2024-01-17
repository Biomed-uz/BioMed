using BioMed.Domain.Entities;
using BioMed.Domain.Interfaces.Repositories;

namespace BioMed.Infrastructure.Persistence.Repositories
{
    public class SpesializationRepository : RepositoryBase<Spesialization>, ISpesializationRepository
    {
        public SpesializationRepository(BioMedDbContext context) : base(context)
        {
        }
    }
}
