using DoMS.Modules.Learning.Domain.Contracts.repositories.Course;
using DoMS.Modules.Learning.Domain.Entities;
using DoMS.Modules.Learning.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoMS.Modules.Learning.Infrastructure.Repositories
{
    internal class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(LearningDbContext dbContext) : base(dbContext) 
        {
            
        }
        public async Task<DoMS.Modules.Learning.Domain.Entities.Course?> GetByNameAsync(string Name, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Course>().AsNoTracking().FirstOrDefaultAsync(p => p.CourseName == Name, cancellationToken);
        }
    }
}
