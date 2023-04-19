using System;
using Domain.Entities;
using Persistence.EFCore.Context;
using Persistence.EFCore.Repositories;

namespace Application.Interfaces.Repositories
{
    public class DocumentGroupRepositoryAsync : EFRepositoryAsync<DocumentGroup>, IDocumentGroupRepositoryAsync
    {
        public DocumentGroupRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
