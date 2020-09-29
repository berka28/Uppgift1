using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        Random temp = new Random();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has been started.");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has been stopped.");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int randomTemp = temp.Next(40);

            try

            {

                if (randomTemp >= 20)

                    _logger.LogInformation($"Temperaturen är {randomTemp} grader och har överskridit gränsnivån");

                else

                    _logger.LogInformation($"Temperaturen är {randomTemp} grader och är inom gränsnivån");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed. - {ex.Message}");
            }

            await Task.Delay(10 * 1000, stoppingToken);

            Console.WriteLine();

        }

    }
}
