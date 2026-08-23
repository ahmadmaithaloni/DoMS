using DoMS.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Domain.Contracts.repositories.GenericRepository
{
    internal interface IGenericRepository<T> where T : InheritableEntity
    {
        Task<T?> GetByIDAsync(Guid ID, CancellationToken cancellationToken);
        Task<IEnumerable<T?>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> AddAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void SoftDelete(T entity);
    }
}
