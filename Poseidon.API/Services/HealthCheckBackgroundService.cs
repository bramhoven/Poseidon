using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Poseidon.BusinessLayer.HealthChecks;
using Poseidon.DataLayer.Cloud;
using Poseidon.DataLayer.HealthChecks;
using Poseidon.DataLayer.Servers;

namespace Poseidon.API.Services
{
    public class HealthCheckBackgroundService : BackgroundServiceBase
    {
        #region Fields

        /// <summary>
        ///     The service provider for getting dependencies.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Properties

        /// <summary>
        ///     The logger.
        /// </summary>
        private ILogger Logger => LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of <see cref="HealthCheckBackgroundService" />
        /// </summary>
        /// <param name="serviceProvider">The server provider</param>
        public HealthCheckBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region Methods

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.Debug("Health check background service is starting");

            stoppingToken.Register(() =>
                Logger.Debug("Health check background service is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var serverDal = scope.ServiceProvider.GetService<IServerDal>();
                    var cloudProviderDal = scope.ServiceProvider.GetService<ICloudProviderDal>();
                    var healthCheckDal = scope.ServiceProvider.GetService<IHealthCheckDal>();
                    var healthCheckManager = new HealthCheckManager(healthCheckDal, serverDal, cloudProviderDal);

                    var result = healthCheckManager.RunHealthChecks();
                    Logger.Info(
                        result ? "Health checks ran successfully" : "Health checks did not run successfully");
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }

                await Task.Delay(BackgroundServiceHelper.HealthCheckDelay, stoppingToken);
            }

            Logger.Debug("Health check background service is stopping.");
        }

        #endregion
    }
}