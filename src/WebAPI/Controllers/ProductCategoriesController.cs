using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Queries.GetAllList;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

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

    [HttpGet]
    public async Task<IDataResult<ListResponse<GetAllListProductCategoryDto>>> GetAllList()
    {
        var getAllListProductCategoryQuery = new GetAllListProductCategoryQuery();
        var result = await Mediator.Send(getAllListProductCategoryQuery);
        return ReturnResult(result);
    }
}
