﻿using BioMed.Domain.Entities;
using BioMed.Domain.Interfaces.Repositories;

namespace BioMed.Infrastructure.Persistence.Repositories
{
    public class VisitRepository : RepositoryBase<Visit>, IVisitRepository
    {
        public VisitRepository(BioMedDbContext context) : base(context)
        {
        }
    }
}
