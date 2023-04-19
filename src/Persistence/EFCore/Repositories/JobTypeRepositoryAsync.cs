using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class JobTypeRepositoryAsync : EFRepositoryAsync<JobType>, IJobTypeRepositoryAsync
    {
        public JobTypeRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
