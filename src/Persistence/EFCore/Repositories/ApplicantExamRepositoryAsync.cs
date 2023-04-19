using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class ApplicantExamRepositoryAsync : EFRepositoryAsync<ApplicantExam>, IApplicantExamRepositoryAsync
    {
        public ApplicantExamRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
