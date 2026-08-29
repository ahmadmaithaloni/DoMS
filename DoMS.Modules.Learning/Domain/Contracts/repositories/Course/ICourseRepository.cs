using DoMS.Modules.Learning.Domain.Contracts.repositories.GenericRepository;
using DoMS.Modules.Learning.Domain.Entities;
using DoMS.Modules.Learning.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Domain.Contracts.repositories.Course
{
    internal interface ICourseRepository : IGenericRepository<DoMS.Modules.Learning.Domain.Entities.Course>
    {
        Task<DoMS.Modules.Learning.Domain.Entities.Course?> GetByNameAsync(string Name, CancellationToken cancellationToken);
    }
}
