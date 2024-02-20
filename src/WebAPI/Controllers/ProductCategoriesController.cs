using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Dtos;
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
    public async Task<IDataResult<CreatedProductCategoryResponse>> Create([FromBody] CreateProductCategoryRequestDto createProductCategoryRequestDto, CancellationToken cancellationToken)
    {
        var command = new CreateProductCategoryCommand(createProductCategoryRequestDto);
        var response = await Mediator.Send(command, cancellationToken);
        return ReturnResult(response);
    }

    [HttpGet]
    public async Task<IDataResult<ListResponse<GetAllListProductCategoryDto>>> GetAllList(CancellationToken cancellationToken)
    {
        var query = new GetAllListProductCategoryQuery();
        var result = await Mediator.Send(query, cancellationToken);
        return ReturnResult(result);
    }
}
