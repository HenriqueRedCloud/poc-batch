using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BatchProcessor.Services
{
    public class BatchProcessingService : IHostedService, IDisposable
    {
        private readonly ILogger<BatchProcessingService> _logger;
        private readonly CsvFileReader _csvFileReader;
        private Timer _timer;

        public BatchProcessingService(ILogger<BatchProcessingService> logger, CsvFileReader csvFileReader)
        {
            _logger = logger;
            _csvFileReader = csvFileReader;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Batch Processing Service is starting.");
            _timer = new Timer(ProcessBatch, null, TimeSpan.Zero, TimeSpan.FromHours(1)); // Process every hour
            return Task.CompletedTask;
        }

        private void ProcessBatch(object state)
        {
            _logger.LogInformation("Batch Processing started at: {time}", DateTimeOffset.Now);
            _csvFileReader.ReadAndProcessCsv("/path/to/staging/folder/products.csv");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Batch Processing Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
