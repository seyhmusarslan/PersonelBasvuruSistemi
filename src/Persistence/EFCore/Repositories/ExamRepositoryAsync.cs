using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class ExamRepositoryAsync : EFRepositoryAsync<Exam>, IExamRepositoryAsync
    {
        public ExamRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
