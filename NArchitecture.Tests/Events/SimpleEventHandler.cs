﻿using NArchitecture.Events;
using System.Threading.Tasks;

namespace NArchitecture.Tests.Events
{
    public class SimpleEventHandler : EventHandler<SimpleEvent>
    {
        protected override Task Handle(SimpleEvent @event)
        {
            return Task.FromResult(0);
        }
    }
}
