using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TechRecruiting.Models;

namespace TechRecruiting.DataGeneration
{
    public class StorageDataGenerator
    {
        private readonly string _connectionString;
        private readonly string _container;

        public StorageDataGenerator(string connectionString, string container)
        {
            _connectionString = connectionString;
            _container = container;
        }

        public async Task GenerateDataAsync(ICollection<Portrait> portraits)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(_connectionString);
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(_container);

            await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob, new BlobRequestOptions(), new OperationContext());
            
            foreach (Portrait item in portraits)
            {
                string filename = Path.GetFileName(item.ImageUrl);
                CloudBlockBlob blob = container.GetBlockBlobReference(filename);
                await blob.UploadFromFileAsync(item.ImageUrl);
                item.ImageUrl = blob.Uri.AbsoluteUri;
            }
        }
    }
}
