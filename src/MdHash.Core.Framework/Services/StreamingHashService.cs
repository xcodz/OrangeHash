using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MdHash.Core.Framework.Abstractions;
using MdHash.Core.Framework.Algorithms;

namespace MdHash.Core.Framework.Services
{
    public sealed class StreamingHashService : IHashService
    {
        public async Task<string> ComputeHashAsync(string filePath, HashAlgorithmKind kind, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is required", nameof(filePath));

            using (var stream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 1024 * 64,
                useAsync: true))
            using (HashAlgorithm algorithm = CreateAlgorithm(kind))
            {
                var buffer = new byte[1024 * 64];
                int read;
                // Use classic ReadAsync(byte[], int, int) for net48 compatibility
                while ((read = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false)) > 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    algorithm.TransformBlock(buffer, 0, read, null, 0);
                }
                algorithm.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
                return ToLowerHex(algorithm.Hash);
            }
        }

        private static HashAlgorithm CreateAlgorithm(HashAlgorithmKind kind)
        {
            switch (kind)
            {
                case HashAlgorithmKind.MD5: return MD5.Create();
                case HashAlgorithmKind.SHA1: return SHA1.Create();
                case HashAlgorithmKind.SHA256: return SHA256.Create();
                default: throw new NotSupportedException("Unsupported algorithm: " + kind);
            }
        }

        private static string ToLowerHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
                sb.Append(bytes[i].ToString("x2"));
            return sb.ToString();
        }
    }
}

