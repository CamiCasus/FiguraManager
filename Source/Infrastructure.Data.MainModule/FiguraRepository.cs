﻿using Domain.MainModule.Entities;
using Domain.MainModule.Interfaces.RepositoryContracts;
using Infrastructure.Data.Core.Context;
using Infrastructure.Data.Core.Repository.EntityFramework;

namespace Infrastructure.Data.MainModule
{
    public class FiguraRepository : Repository<Figura, int>, IFiguraRepository
    {
        public FiguraRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
