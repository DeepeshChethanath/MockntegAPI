using MediatR;
using Microsoft.AspNetCore.Mvc;
using MockIntegAPI.Models;

namespace MockIntegAPI.Commands
{
    //for creating products
    public record CreateProductCommand(ProductRequest productRequest) : IRequest<IActionResult>;
}
