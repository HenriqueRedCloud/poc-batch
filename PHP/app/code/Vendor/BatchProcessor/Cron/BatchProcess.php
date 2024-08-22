<?php
namespace Vendor\BatchProcessor\Cron;

use Vendor\BatchProcessor\Model\ImportHandler;
use Psr\Log\LoggerInterface;

class BatchProcess
{
    protected $importHandler;
    protected $logger;

    public function __construct(
        ImportHandler $importHandler,
        LoggerInterface $logger
    ) {
        $this->importHandler = $importHandler;
        $this->logger = $logger;
    }

    public function execute()
    {
        try {
            $this->importHandler->processBatch();
            $this->logger->info("Batch processing completed successfully.");
        } catch (\Exception $e) {
            $this->logger->error("Error during batch processing: " . $e->getMessage());
        }
    }
}
