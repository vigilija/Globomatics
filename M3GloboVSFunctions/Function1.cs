using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace M3GloboVSFunctions
{
    public static class Function1
    {
        [FunctionName("VSLocationsFromQueue")]
        public static void Run([QueueTrigger("locations", Connection = "")]string myQueueItem, 
            [CosmosDB("m3globocdb", "globolocations", ConnectionStringSetting ="m3globocosmos_DOCUMENTDB")] out object locationDocument,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            locationDocument = new
            {
                id = System.Guid.NewGuid().ToString(),
              //  country = location.country,
              //  Name = location.Name,
              //  Address = location.Address,
              //  Telephone = location.Telephone
            };
        }
    }
}
