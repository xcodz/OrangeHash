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
        public async Task<string> ComputeHashAsync(string filePath, HashAlgorithmKind kind, IProgress<double> progress, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is required", nameof(filePath));

            const int bufferSize = 1024 * 64;
            var buffer = new byte[bufferSize];
            long totalBytesRead = 0;

            using (var stream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: bufferSize,
                useAsync: true))
            {
                var fileLength = stream.Length;
                int read;

                if (kind == HashAlgorithmKind.SHA384 || kind == HashAlgorithmKind.SHA512)
                {
                    var algName = kind == HashAlgorithmKind.SHA384 ? HashAlgorithmName.SHA384 : HashAlgorithmName.SHA512;
                    using (var ih = IncrementalHash.CreateHash(algName))
                    {
                        while ((read = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) > 0)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            ih.AppendData(buffer, 0, read);
                            totalBytesRead += read;
                            progress?.Report((double)totalBytesRead / fileLength);
                        }
                        var hashBytes = ih.GetHashAndReset();
                        progress?.Report(1.0);
                        return ToLowerHex(hashBytes);
                    }
                }
                else
                {
                    using (HashAlgorithm algorithm = CreateAlgorithm(kind))
                    using (var crypto = new CryptoStream(Stream.Null, algorithm, CryptoStreamMode.Write))
                    {
                        while ((read = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) > 0)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            crypto.Write(buffer, 0, read);
                            totalBytesRead += read;
                            progress?.Report((double)totalBytesRead / fileLength);
                        }
                        crypto.FlushFinalBlock();
                        progress?.Report(1.0);
                        return ToLowerHex(algorithm.Hash);
                    }
                }
            }
        }

        private static HashAlgorithm CreateAlgorithm(HashAlgorithmKind kind)
        {
            switch (kind)
            {
                case HashAlgorithmKind.MD5:
                    return MD5.Create();
                case HashAlgorithmKind.SHA1:
                    return SHA1.Create();
                case HashAlgorithmKind.SHA256:
                    return SHA256.Create();
                case HashAlgorithmKind.SHA384:
                    try { return System.Security.Cryptography.SHA384Cng.Create(); } catch { }
                    return SHA384.Create();
                case HashAlgorithmKind.SHA512:
                    try { return System.Security.Cryptography.SHA512Cng.Create(); } catch { }
                    return SHA512.Create();
                default:
                    throw new NotSupportedException("Unsupported algorithm: " + kind);
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
