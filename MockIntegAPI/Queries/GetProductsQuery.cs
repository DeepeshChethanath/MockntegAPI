using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MockIntegAPI.Queries
{
    //for retriving products
    public record GetProductsQuery(string? Name, int Page, int PageSize) : IRequest<IActionResult>;
}
