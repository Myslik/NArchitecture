﻿using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Tests.Requests;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NArchitecture.Tests
{
    public class RequestTests
    {
        private IBus CreateBus(Action<BusOptions> configure)
        {
            var services = new ServiceCollection();
            services.AddBus(configure);
            var provider = services.BuildServiceProvider();
            return provider.GetService<IBus>();
        }

        [Fact]
        public async Task SendSimpleRequest()
        {
            var bus = CreateBus(o =>
            {
                o.AddRequestHandler<SimpleRequestHandler>();
            });

            await bus.Request(new SimpleRequest());
        }

        [Fact]
        public async Task SendSimpleRequestFailTest()
        {
            var bus = CreateBus(o =>
            {
                o.AddRequestHandler<SimpleRequestHandlerFailing>();
            });

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                return bus.Request(new SimpleRequest());
            });
        }

        [Fact]
        public async Task SendSimpleRequestWithoutHandlerTest()
        {
            var bus = CreateBus(o => { });
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                return bus.Request(new SimpleRequest());
            });
        }

        [Fact]
        public async Task SendSimpleRequestWithTooManyHandlersTest()
        {
            var bus = CreateBus(o =>
            {
                o.AddRequestHandler<SimpleRequestHandler>();
                o.AddRequestHandler<SimpleRequestHandlerFailing>();
            });

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                return bus.Request(new SimpleRequest());
            });
        }

        [Fact]
        public async Task SendComplexRequest()
        {
            var bus = CreateBus(o =>
            {
                o.AddRequestHandler<ComplexRequestHandler>();
            });

            await bus.Request(new ComplexRequest());
        }

        [Fact]
        public async Task SendComplexRequestFailTest()
        {
            var bus = CreateBus(o =>
            {
                o.AddRequestHandler<ComplexRequestHandlerFailing>();
            });

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                return bus.Request(new ComplexRequest());
            });
        }

        [Fact]
        public async Task SendComplexRequestWithoutHandlerTest()
        {
            var bus = CreateBus(o => { });
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                return bus.Request(new ComplexRequest());
            });
        }

        [Fact]
        public async Task SendComplexRequestWithTooManyHandlersTest()
        {
            var bus = CreateBus(o =>
            {
                o.AddRequestHandler<ComplexRequestHandler>();
                o.AddRequestHandler<ComplexRequestHandlerFailing>();
            });

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                return bus.Request(new ComplexRequest());
            });
        }
    }
}
