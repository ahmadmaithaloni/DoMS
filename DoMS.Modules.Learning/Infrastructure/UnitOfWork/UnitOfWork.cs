using DoMS.Modules.Learning.Domain.Contracts.repositories.Course;
using DoMS.Modules.Learning.Domain.Contracts.repositories.Learner;
using DoMS.Modules.Learning.Domain.Contracts.UnitOfWork;
using DoMS.Modules.Learning.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Infrastructure.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LearningDbContext _dbContext;
        
        public UnitOfWork(LearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
