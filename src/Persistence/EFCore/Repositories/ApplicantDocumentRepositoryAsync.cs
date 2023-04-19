using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class ApplicantDocumentRepositoryAsync : EFRepositoryAsync<ApplicantDocument>, IApplicantDocumentRepositoryAsync
    {
        public ApplicantDocumentRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
