using MediatR;
using Microsoft.AspNetCore.Mvc;
using MockIntegAPI.Commands;
using MockIntegAPI.Helpers;

namespace MockIntegAPI.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IActionResult>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiConfiguration _apiConfig;

        public DeleteProductCommandHandler(IHttpClientFactory httpClientFactory, ApiConfiguration apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }

        public async Task<IActionResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = HttpClientHelper.Create(_httpClientFactory);
                var response = await client.DeleteAsync($"{_apiConfig.BaseUrl}/objects/{request.Id}");

                if (!response.IsSuccessStatusCode)
                    return new BadRequestObjectResult("Failed Product Deletion");

                return new OkObjectResult("Product Deletion Completed Successfully.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error while Product Deletion -- " + ex.Message);
            }
        }
    }
}
