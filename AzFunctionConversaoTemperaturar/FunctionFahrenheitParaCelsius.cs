using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzFunctionConversaoTemperaturar
{
    public class FunctionFahrenheitParaCelsius
    {
        private readonly ILogger<FunctionFahrenheitParaCelsius> _logger;

        public FunctionFahrenheitParaCelsius(ILogger<FunctionFahrenheitParaCelsius> logger)
        {
            _logger = logger;
        }

        [Function("ConverterFahrenheitParaCelsius")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ConverterFahrenheitParaCelsius/{fahrenheit}")] HttpRequest req, double fahrenheit)
        {
            _logger.LogInformation($"Parâmetro recebido: {fahrenheit}", fahrenheit);

            var valorEmCelsius = (fahrenheit - 32) * 5 / 9;

            string respondeMessage = $"O valor em Fahrenheit {fahrenheit} em Celsius é: {valorEmCelsius}";

            return new OkObjectResult(respondeMessage);
        }
    }
}
