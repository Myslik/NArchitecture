﻿using NArchitecture;
using System.Threading;
using System.Threading.Tasks;

namespace NArchitecture.Tests
{
    internal class ComplexRequestHandler : IHandleRequest<ComplexRequest, int>
    {
        public const int RETURN_VALUE = 1;

        public Task<int> Handle(ComplexRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(RETURN_VALUE);
        }
    }
}
