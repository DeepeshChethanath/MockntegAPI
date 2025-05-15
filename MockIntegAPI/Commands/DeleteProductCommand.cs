using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MockIntegAPI.Commands
{
    //for deleting products
    public record DeleteProductCommand(string Id): IRequest<IActionResult>;
}
