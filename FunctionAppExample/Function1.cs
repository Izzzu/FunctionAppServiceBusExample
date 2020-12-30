using System.Threading;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace FunctionAppExample
{
    public class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [ServiceBusTrigger("stocktransfers", Connection = "StockTransfersConnectionString")] string myQueueItem, ILogger logger)
        {
            // host.json - maxConcurrentCalls set to 2 - 2 instances in parallel can process messages
            Thread.Sleep(5000);
            logger.LogInformation($"ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}

/*
 * add local.settings.json
 *
 {
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet",
        "StockTransfersConnectionString": "CONN_STRING_TO_SERVICE_BUS_QUEUE"
    }
}
*/