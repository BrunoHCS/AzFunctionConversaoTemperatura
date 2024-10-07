using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzFunctionConversaoTemperaturar
{
    public class FunctionCelsiusParaFahrenheit
    {
        private readonly ILogger<FunctionCelsiusParaFahrenheit> _logger;

        public FunctionCelsiusParaFahrenheit(ILogger<FunctionCelsiusParaFahrenheit> logger)
        {
            _logger = logger;
        }

        [Function("ConverterCelsiusParaFahrenheit")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ConverterCelsiusParaFahrenheit/{celsius}")] HttpRequest req, double celsius)
        {
            _logger.LogInformation($"Parâmetro recebido: {celsius}", celsius);

            var valorEmFahrenheit = ((celsius * 9) / 5) + 32;

            string respondeMessage = $"O valor em Celsius {celsius} em Fahrenheit é: {valorEmFahrenheit}";

            return new OkObjectResult(respondeMessage);
        }
    }
}
