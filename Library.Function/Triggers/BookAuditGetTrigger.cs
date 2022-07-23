using System.Collections.Generic;
using Library.Function.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Library.Function.Triggers;

public static class BookAuditGetTrigger
{
    [FunctionName("BookAuditGetTrigger")]
    public static IActionResult RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest request, 
        [CosmosDB(databaseName: "Library", collectionName: "BookAudit", SqlQuery = "SELECT * FROM BookAudit", ConnectionStringSetting = "CosmosDbConnection")] IEnumerable<BookAuditModel> bookAudit)
    {
        return new OkObjectResult(bookAudit);
    }
}