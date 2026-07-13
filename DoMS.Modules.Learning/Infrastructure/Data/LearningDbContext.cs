using DoMS.Modules.Learning.Domain.Entities;
using DoMS.Modules.Learning.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DoMS.Modules.Learning.Infrastructure.Data;

public class LearningDbContext : DbContext
{
    public LearningDbContext(DbContextOptions<LearningDbContext> options) : base(options)
    {

    }
    
    public DbSet<Course> Courses { get; init; }
    public DbSet<CourseAssignment> CourseAssignments { get; init; }
    public DbSet<Learner> Learners { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(LearningDbContext).Assembly);
    }
}