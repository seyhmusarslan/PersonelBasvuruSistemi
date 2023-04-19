using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class ApplicantRepositoryAsync : EFRepositoryAsync<Applicant>, IApplicantRepositoryAsync
    {
        public ApplicantRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
