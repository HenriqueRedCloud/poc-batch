# Magento 2 Batch Processing Module

## Overview

This Magento 2 module enables batch processing for product imports using CSV files. The module is designed to run as a scheduled cron job, processing CSV files from a specified staging directory and importing the product data into the Magento catalog.

## Features

- Scheduled batch processing via Magento's cron job system.
- Imports product data from CSV files.
- Error logging and reporting.
- Simple setup and integration with the Magento 2 ecosystem.

## Requirements

- Magento 2.4.x
- PHP 7.4 or PHP 8.0
- Access to the Magento Admin Panel for configuration

## Installation

1. **Clone or Download the Module:**
   - Place the module code in `app/code/Vendor/BatchProcessor`.

2. **Enable the Module:**
   ```php bin/magento module:enable Vendor_BatchProcessor```
   ```php bin/magento setup:upgrade```
   ```php bin/magento cache:clean```

3. **Configure Cron Jobs:**
    - Ensure that Magento cron jobs are configured and running on your server. The batch processing job is scheduled to run every hour by default.


## Usage
- Upload CSV Files:

Place your CSV files in the designated staging folder, which you can configure in the module's ImportHandler.php file.

- CSV File Format:

Ensure your CSV files are formatted according to Magento's import requirements (e.g., SKU, Name, Price, Quantity).

- Monitor Logs:

Logs for the batch processing job can be found in the var/log/batchprocessor.log file.
Errors and status messages are logged to help you monitor the import process.

## Customization

- Batch Frequency:

Modify the cron schedule in etc/crontab.xml to change how often the batch processing runs.

- Staging Folder:

Adjust the file path in Model/ImportHandler.php to point to the correct staging directory for your CSV files.