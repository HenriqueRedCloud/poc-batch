# .NET Core 8 Batch Processing Service

## Overview

This .NET Core 8 service is designed to process product data from CSV files and update a Magento 2 store via its REST API. The service runs as a hosted application, periodically processing the CSV files using a batch processing approach.

## Features

- Periodic batch processing using a timer (default: every hour).
- Reads product data from CSV files and updates Magento 2 via REST API.
- Detailed logging with Serilog for error tracking and status reporting.
- Simple to configure and extend.

## Requirements

- .NET Core 8.0 SDK
- Access to a Magento 2 instance with REST API enabled
- CSV file formatted according to Magento's import requirements

## Installation

1. **Clone or Download the Project:**
   - Place the project in your desired directory.

2. **Restore Dependencies:**
   ```dotnet restore```

3. **Build the Project:**
```dotnet build```

## Usage
### Run the Service:

Start the service by running:
```dotnet run```
Alternatively, deploy the service as a Windows or Linux service for continuous operation.

### CSV File Location:

Place your CSV file in the specified folder (/path/to/staging/folder/products.csv).

### Monitor Logs:

Logs are written to logs/batchprocessor.log for monitoring the status of the batch processing and any errors encountered.

## Configuration
### Batch Frequency:

Modify the timer interval in Services/BatchProcessingService.cs to change how often the batch processing occurs.

### CSV File Path:

Adjust the file path in Services/CsvFileReader.cs to point to your staging directory for CSV files.

### API Configuration:

Update the API endpoints in CsvFileReader.cs to match your Magento 2 REST API configuration.