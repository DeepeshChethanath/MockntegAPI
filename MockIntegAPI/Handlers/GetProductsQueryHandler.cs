using MediatR;
using Microsoft.AspNetCore.Mvc;
using MockIntegAPI.Helpers;
using MockIntegAPI.Models;
using MockIntegAPI.Queries;

namespace MockIntegAPI.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IActionResult>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiConfiguration _apiConfig;

        public GetProductsQueryHandler(IHttpClientFactory httpClientFactory, ApiConfiguration apiConfig)
        {
            _httpClientFactory = httpClientFactory;
            _apiConfig = apiConfig;
        }
        public async Task<IActionResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var client = HttpClientHelper.Create(_httpClientFactory);
                var response = await client.GetFromJsonAsync<List<ProductResponse>>($"{_apiConfig.BaseUrl}/objects");
                if (response == null)
                    return new BadRequestObjectResult("No Data Available");

                var responseFiltered = response
                    .Where(p => string.IsNullOrWhiteSpace(request.Name) || (p.Name?.Contains(request.Name, StringComparison.OrdinalIgnoreCase) ?? false))
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                return new OkObjectResult(responseFiltered);
            }
            catch (Exception ex) 
            {
                return new BadRequestObjectResult("Error Occured" + ex.Message);
            }
        }
    }
}
