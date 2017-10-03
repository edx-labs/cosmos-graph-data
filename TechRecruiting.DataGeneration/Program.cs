using PromptLibrary;
using System.Configuration;

namespace TechRecruiting.DataGeneration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string DEFAULT_STORAGE_CONTAINER_NAME = ConfigurationManager.AppSettings["StorageContainerName"];
            string DEFAULT_COSMOS_DATABASE_NAME = ConfigurationManager.AppSettings["CosmosDatabaseName"];
            string DEFAULT_COSMOS_GRAPH_NAME = ConfigurationManager.AppSettings["CosmosGraphName"];

            Prompt.Title("Graph Lab Data Generation");
            Prompt.Say("Before generating the sample data, you will be required to provide information about your Azure Cosmos DB instance.");

            string storageConnectionString = Prompt.Ask<string>("What is your Storage Account's connection string?");
            string endpointUrl = Prompt.Ask<string>("What is the Endpoint URL for your Azure Cosmos DB instance?");
            string accountKey = Prompt.Ask<string>("What is the Primary Account Key for your Azure Cosmos DB instance?");
            string databaseName = Prompt.Ask<string>("What is the name of the database that will be created?", DEFAULT_COSMOS_DATABASE_NAME);
            string graphName = Prompt.Ask<string>("What is the name of the graph that will be created?", DEFAULT_COSMOS_GRAPH_NAME);

            Prompt.Say("Uploading images to Azure Storage account.");

            SamplePortraitDataCollection samplePortraitsData = new SamplePortraitDataCollection();
            StorageDataGenerator storageGenerator = new StorageDataGenerator(storageConnectionString, DEFAULT_STORAGE_CONTAINER_NAME);
            storageGenerator.GenerateDataAsync(samplePortraitsData).Wait();

            Prompt.Say("Uploading sample data to Azure Cosmos DB account.");

            SampleCandidatesDataCollection sampleCandidatesData = new SampleCandidatesDataCollection();
            SampleRecruitersDataCollection sampleRecruitersData = new SampleRecruitersDataCollection();
            SampleAcquaintancesDataCollection sampleAcquaintancesData = new SampleAcquaintancesDataCollection();
            GraphDataGenerator graphGenerator = new GraphDataGenerator(accountKey, endpointUrl, databaseName, graphName);
            graphGenerator.GenerateDataAsync(samplePortraitsData, sampleCandidatesData, sampleRecruitersData, sampleAcquaintancesData).Wait();

            Prompt.Say("Your Azure Cosmos DB graph has been created.");
             
            Prompt.PressAnyKeyToContinue();
        }
    }
}