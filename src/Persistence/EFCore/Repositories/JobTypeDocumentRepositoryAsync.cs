using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class JobTypeDocumentRepositoryAsync : EFRepositoryAsync<JobTypeDocument>, IJobTypeDocumentRepositoryAsync
    {
        public JobTypeDocumentRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
