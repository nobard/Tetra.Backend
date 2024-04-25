﻿using Microsoft.EntityFrameworkCore;
using Tetra.Domain;

namespace Tetra.Application.Interfaces
{
    public interface IRequestsDbContext
    {
        DbSet<RequestDomain> Requests { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
