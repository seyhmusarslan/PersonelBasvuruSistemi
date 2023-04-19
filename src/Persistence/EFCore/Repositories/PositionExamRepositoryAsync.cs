using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class PositionExamRepositoryAsync : EFRepositoryAsync<PositionExam>, IPositionExamRepositoryAsync
    {
        public PositionExamRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
