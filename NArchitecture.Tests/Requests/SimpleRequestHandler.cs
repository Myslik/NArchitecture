﻿using NArchitecture.Requests;
using System.Threading.Tasks;

namespace NArchitecture.Tests.Requests
{
    public class SimpleRequestHandler : RequestHandler<SimpleRequest>
    {
        protected override Task Handle(SimpleRequest request)
        {
            return Task.FromResult(0);
        }
    }
}
