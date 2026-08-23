using DoMS.Modules.Learning.Domain.Contracts.repositories.GenericRepository;
using DoMS.Modules.Learning.Infrastructure.Data;
using DoMS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Infrastructure.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : InheritableEntity
    {
        // db context injection:
        protected readonly LearningDbContext _dbContext;
        public GenericRepository(LearningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetByIDAsync(Guid ID, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FindAsync(new object[] { ID }, cancellationToken);
        }
        public async Task<IEnumerable<T?>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<T?> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }
        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        public void SoftDelete(T entity)
        {
            entity.IsActive = false;
            _dbContext.Set<T>().Update(entity);
        }
    }
}
