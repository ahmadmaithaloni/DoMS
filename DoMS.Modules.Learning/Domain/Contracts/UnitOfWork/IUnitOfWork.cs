using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Domain.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
