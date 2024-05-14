namespace Tetra.Application.Interfaces
{
    public interface IPasswordHasher : IDisposable
    {
        Task<byte[]> Hash(string password);
    }
}
