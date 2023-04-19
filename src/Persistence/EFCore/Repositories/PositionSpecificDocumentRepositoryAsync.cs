using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class PositionSpecificDocumentRepositoryAsync : EFRepositoryAsync<PositionSpecificDocument>, IPositionSpecificDocumentRepositoryAsync
    {
        public PositionSpecificDocumentRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
