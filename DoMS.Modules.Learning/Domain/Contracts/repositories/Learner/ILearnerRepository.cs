using DoMS.Modules.Learning.Domain.Contracts.repositories.GenericRepository;
using DoMS.Modules.Learning.Domain.Entities;
using DoMS.Modules.Learning.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Domain.Contracts.repositories.Learner
{
    internal interface ILearnerRepository : IGenericRepository<DoMS.Modules.Learning.Domain.Entities.Learner>
    {
        Task<DoMS.Modules.Learning.Domain.Entities.Learner?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        
        Task<DoMS.Modules.Learning.Domain.Entities.Learner?> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}
