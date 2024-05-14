using System.Security.Cryptography;
using System.Text;
using Tetra.Application.Interfaces;

namespace Tetra.Persistence.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly HMACSHA512 x = new(Encoding.UTF8.GetBytes("Security"));

        public Task<byte[]> Hash(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var allBytes = new byte[bytes.Length];

            Buffer.BlockCopy(bytes, 0, allBytes, 0, bytes.Length);

            return x.ComputeHashAsync(new MemoryStream(allBytes));
        }

        public void Dispose() => x.Dispose();
    }
}
