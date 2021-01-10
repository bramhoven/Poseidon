namespace Poseidon.API.Services
{
    public static class BackgroundServiceHelper
    {
        /// <summary>
        /// Gets the delay between health checks in milliseconds.
        /// </summary>
        public static int HealthCheckDelay = 300000; // Every 5 minutes
    }
}