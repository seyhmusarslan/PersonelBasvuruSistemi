using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class PositionRepositoryAsync : EFRepositoryAsync<Position>, IPositionRepositoryAsync
    {
        public PositionRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
