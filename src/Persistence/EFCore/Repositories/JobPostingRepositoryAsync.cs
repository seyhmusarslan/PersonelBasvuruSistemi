using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class JobPostingRepositoryAsync : EFRepositoryAsync<JobPosting>, IJobPostingRepositoryAsync
    {
        public JobPostingRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
