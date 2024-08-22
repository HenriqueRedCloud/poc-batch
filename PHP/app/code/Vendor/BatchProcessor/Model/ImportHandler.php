<?php
namespace Vendor\BatchProcessor\Model;

use Magento\ImportExport\Model\Import;
use Magento\Framework\Filesystem\Io\File;

class ImportHandler
{
    protected $importModel;
    protected $fileIo;

    public function __construct(
        Import $importModel,
        File $fileIo
    ) {
        $this->importModel = $importModel;
        $this->fileIo = $fileIo;
    }

    public function processBatch()
    {
        $filePath = '/path/to/staging/folder/products.csv'; // Path to your CSV file
        if ($this->fileIo->fileExists($filePath)) {
            $this->importModel->setData([
                'entity' => 'catalog_product',
                'behavior' => 'append'
            ]);
            $this->importModel->setFilePath($filePath);
            $this->importModel->importSource();
        }
    }
}
