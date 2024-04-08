using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Transactionb2b
{
    public static class Function1
    {
        public class InputPayload
        {
            public string Source { get; set; }
            public string Prompt { get; set; }
        }

        [FunctionName("SendPrompt")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function received a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            InputPayload data = JsonConvert.DeserializeObject<InputPayload>(requestBody);

            // Você pode fazer algo com 'data.Source' e 'data.Prompt' aqui, se necessário

            var response = new { transactionID = "123", status = "scheduled" };
            return new OkObjectResult(response);
        }
    }
}
