using System;
using System.Threading.Tasks;
using Library.Function.Models;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Library.Function.Triggers;

public static class BookAddedTrigger
{
    [FunctionName("BookAddedTrigger")]
    public static async Task RunAsync(
        [ServiceBusTrigger("book-audit", Connection = "ServiceBusConnection")] string message,
        [CosmosDB("Library", "BookAudit", ConnectionStringSetting = "CosmosDbConnection")] IAsyncCollector<BookAuditModel> documentsOut)
    {
        var model = JsonConvert.DeserializeObject<BookAuditModel>(message);
        model.Id = Guid.NewGuid();
        await documentsOut.AddAsync(model);
    }
}