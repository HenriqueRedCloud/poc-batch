using CsvHelper;
using System.Globalization;
using BatchProcessor.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace BatchProcessor.Services
{
    public class CsvFileReader
    {
        private readonly ILogger<CsvFileReader> _logger;
        private readonly HttpClient _httpClient;

        public CsvFileReader(ILogger<CsvFileReader> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public void ReadAndProcessCsv(string filePath)
        {
            if (File.Exists(filePath))
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<Product>();
                foreach (var record in records)
                {
                    // Process each record (e.g., send to Magento API)
                    var response = _httpClient.PutAsJsonAsync($"https://your-magento-store.com/rest/V1/products/{record.Sku}", record).Result;
                    _logger.LogInformation("Processed product SKU: {sku}, Status: {status}", record.Sku, response.StatusCode);
                }
            }
            else
            {
                _logger.LogError("CSV file not found at path: {path}", filePath);
            }
        }
    }
}
