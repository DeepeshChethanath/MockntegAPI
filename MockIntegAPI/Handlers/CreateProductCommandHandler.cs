using MediatR;
using Microsoft.AspNetCore.Mvc;
using MockIntegAPI.Commands;
using MockIntegAPI.Helpers;
using MockIntegAPI.Models;

namespace MockIntegAPI.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IActionResult>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiConfiguration _apiConfig;

        public CreateProductCommandHandler(IHttpClientFactory httpClientFactory, ApiConfiguration apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }
        public async Task<IActionResult> Handle(CreateProductCommand requestCommand, CancellationToken cancellationToken)
        {
            var request = requestCommand.productRequest;

            if (request.Data == null || !request.Data.Any())
                return new BadRequestObjectResult("Data cannot be null or empty!!");

            if (string.IsNullOrWhiteSpace(request.Name))
                return new BadRequestObjectResult("Name cannot be empty");

            try
            {
                var client = HttpClientHelper.Create(_httpClientFactory);
                var response = await client.PostAsJsonAsync($"{_apiConfig.BaseUrl}/objects", request);

                if (!response.IsSuccessStatusCode)
                    return new BadRequestObjectResult("Failed Product Creation");

                var createdProduct = await response.Content.ReadFromJsonAsync<ProductResponse>();
                return new OkObjectResult(createdProduct);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error while Product Creation -- " + ex.Message);
            }
        }
    }
}
