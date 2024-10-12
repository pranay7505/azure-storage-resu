using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;

using Microsoft.Azure.Cosmos;


#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Company.Function
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"azureResume", containerName: "Counter", Connection = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] Counter counter,
            [CosmosDB(databaseName:"azureResume", containerName: "Counter", Connection = "AzureResumeConnectionString", Id = "1", PartitionKey = "1")] out Counter updatedCounter,


            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Count += 1;


            var jsonToRetun = JsonConvert.SerializeObject(counter);

            
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToRetun, Encoding.UTF8, "application/json")
            };
        }
    }
}
