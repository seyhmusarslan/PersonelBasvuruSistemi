using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class ApplicantStatuRepositoryAsync : EFRepositoryAsync<ApplicantStatu>, IApplicantStatuRepositoryAsync
    {
        public ApplicantStatuRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
