using Core.Middlewares;
using ExampleServer.Sockets;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceExtensions
    {
        public static IApplicationBuilder StartTCPServer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TcpServerMiddleware>();
        }
    }
}
