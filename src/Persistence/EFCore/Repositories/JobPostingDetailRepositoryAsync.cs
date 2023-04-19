using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class JobPostingDetailRepositoryAsync : EFRepositoryAsync<JobPostingDetail>, IJobPostingDetailRepositoryAsync
    {
        public JobPostingDetailRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
