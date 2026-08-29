using DoMS.Modules.Learning.Domain.Contracts.repositories.Learner;
using DoMS.Modules.Learning.Domain.Entities;
using DoMS.Modules.Learning.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DoMS.Modules.Learning.Infrastructure.Repositories
{
    internal class LearnerRepository : GenericRepository<DoMS.Modules.Learning.Domain.Entities.Learner>, ILearnerRepository
    {
        public LearnerRepository(LearningDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<DoMS.Modules.Learning.Domain.Entities.Learner?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Learner>().AsNoTracking().FirstOrDefaultAsync(p => p.Email == email, cancellationToken);
        }
        public async Task<DoMS.Modules.Learning.Domain.Entities.Learner?> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Learner>().AsNoTracking().FirstOrDefaultAsync(p => p.LearnerName == name, cancellationToken);
        }
    }
}
