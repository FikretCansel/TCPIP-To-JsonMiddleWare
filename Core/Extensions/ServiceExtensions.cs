using ExampleServer.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection StartTCPServer(this IServiceCollection services, int port, int maxQueue)
        {
            Listener listener = new Listener(port, maxQueue);

            listener.Start();

            return services;
        }
    }
}
