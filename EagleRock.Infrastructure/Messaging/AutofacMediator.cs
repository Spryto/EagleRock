using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using EagleRock.Infrastructure;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Core.Enrichers;

namespace EagleRock.Infrastructure
{
    sealed class AutofacMediator : IMediator
    {
        static readonly ILogger Log = Serilog.Log.ForContext<AutofacMediator>();

        readonly ILifetimeScope scope;
        readonly IHostEnvironment environment;

        public AutofacMediator(ILifetimeScope scope, IHostEnvironment environment)
        {
            this.scope = scope;
            this.environment = environment;
        }

        public async Task Command<TCommand>(
            TCommand command,
            CancellationToken cancellationToken)
            where TCommand : class, ICommand
        {
            Task Handler(TCommand message, CancellationToken token)
            {
                var handler = scope.Resolve<ICommandHandler<TCommand>>();
                return handler.HandleAsync(message, token);
            }

            var enrichers = new ILogEventEnricher[]
            {
                new PropertyEnricher("Message", command.GetType().Name)
            };

            ExceptionDispatchInfo exceptionDispatchInfo = null;
            using (LogContext.Push(enrichers))
            {
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    await Handler(command, cancellationToken);
                }
                catch (Exception ex)
                {
                    LogError(command, ex);
                    exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
                }
                finally
                {
                    stopwatch.Stop();
                }

                if (exceptionDispatchInfo != null)
                {
                    Log.Information("{MessageType} terminated. {Elapsed:0.0000} ms",
                        command.GetType().Name, stopwatch.Elapsed.TotalMilliseconds);

                    exceptionDispatchInfo.Throw();
                }

                Log.Information("{MessageType} completed. {Elapsed:0.0000} ms",
                    command.GetType().Name, stopwatch.Elapsed.TotalMilliseconds);
            }
        }

        public async Task<TQueryResponse> Query<TQuery, TQueryResponse>(
            TQuery query,
            CancellationToken cancellationToken)
            where TQuery : IQuery<TQueryResponse>
            where TQueryResponse : class, IQueryResponse
        {
            Task<TQueryResponse> Handler(TQuery message, CancellationToken token)
            {
                var handler = scope.Resolve<IQueryHandler<TQuery, TQueryResponse>>();
                return handler.HandleAsync(message, token);
            }

            var enrichers = new ILogEventEnricher[]
            {
                new PropertyEnricher("Message", query.GetType().Name)
            };

            TQueryResponse response = default;
            ExceptionDispatchInfo exceptionDispatchInfo = null;
            using (LogContext.Push(enrichers))
            {
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    response = await Handler(query, cancellationToken);
                }
                catch (Exception ex)
                {
                    LogError(query, ex);
                    exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
                }
                finally
                {
                    stopwatch.Stop();
                }

                if (exceptionDispatchInfo != null)
                {
                    Log.Information("{MessageType} terminated. {Elapsed:0.0000} ms",
                        query.GetType().Name, stopwatch.Elapsed.TotalMilliseconds);

                    exceptionDispatchInfo.Throw();
                }

                Log.Information("{MessageType} completed. {Elapsed:0.0000} ms",
                    query.GetType().Name, stopwatch.Elapsed.TotalMilliseconds);
            }

            return response;
        }

        void LogError(object message, Exception exception)
        {
            Log.Error(exception, "{Message}", message.GetType().Name);

            const string RequestBody = "RequestBody";

            string body = null;
            if (environment.IsDevelopment() && exception.Data.Contains(RequestBody))
            {
                body = exception.Data[RequestBody] as string;
            }

            if (!string.IsNullOrEmpty(body))
            {
                Log.Information("Request {Content}", body);
            }
        }
    }
}