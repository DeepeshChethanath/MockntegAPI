using MediatR;
using Microsoft.AspNetCore.Mvc;
using MockIntegAPI.Commands;
using MockIntegAPI.Models;
using MockIntegAPI.Queries;

namespace MockIntegAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get(string name, int page = 1, int pagesize = 10)
        {
            var result = await _mediator.Send(new GetProductsQuery(name, page, pagesize));
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequest productRequest)
        {
            var result = await _mediator.Send(new CreateProductCommand(productRequest));
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return result;
        }
    }
}
