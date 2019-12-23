using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        // private readonly ICurrentUserService _currentUserService;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)//, ICurrentUserService currentUserService)
        {
            _timer = new Stopwatch();

            _logger = logger;
            // _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                // _logger.LogWarning("IEC Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                //     name, _timer.ElapsedMilliseconds, _currentUserService.UserId, request);

                _logger.LogWarning("IEC Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                name, _timer.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}