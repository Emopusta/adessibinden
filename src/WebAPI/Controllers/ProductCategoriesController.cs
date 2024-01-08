using Application.Features.ProductCategories.Commands.Create;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : BaseController
    {
        [HttpPost]
        public async Task<IDataResult<CreatedProductCategoryResponse>> Create([FromBody] CreateProductCategoryCommand createProductCategoryCommand)
        {
            var response = await Mediator.Send(createProductCategoryCommand);

            return ReturnResult(response);
        }
    }
}
