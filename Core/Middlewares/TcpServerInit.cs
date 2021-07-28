using ExampleServer.Sockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Core.Middlewares
{
    public class TcpServerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly int _port;
        private readonly int _maxQueue;

        public TcpServerMiddleware(RequestDelegate next)
        {
            _next = next;
            _port = 3001;
            _maxQueue = 50;
        }

        // IMyScopedService is injected into Invoke
        public async System.Threading.Tasks.Task Invoke(HttpContext httpContext)
        {
            Listener listener = new Listener(_port, _maxQueue);

            listener.Start();
        }
    }
}