using Application.Features.Products.Commands.Create;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpPost]
        public async Task<IDataResult<CreatedProductResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await Mediator.Send(createProductCommand);

            return ReturnResult(response);
        }
    }
}
