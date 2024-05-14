namespace Tetra.Application.Interfaces
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
