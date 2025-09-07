using System;
using System.Threading;
using System.Threading.Tasks;
using MdHash.Core.Framework.Algorithms;

namespace MdHash.Core.Framework.Abstractions
{
    public interface IHashService
    {
        Task<string> ComputeHashAsync(string filePath, HashAlgorithmKind kind, IProgress<double> progress, CancellationToken cancellationToken = default);
    }
}

