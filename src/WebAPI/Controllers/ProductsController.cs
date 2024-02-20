using Application.Features.Products.Dtos;
using Application.Features.Products.Queries.GetAllPaginated;
using Application.Features.Products.Queries.GetByCreatorUserIdPaginated;
using Application.Features.Products.Queries.GetByTitlePaginated;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet("GetByCreator")]
        public async Task<IDataResult<PaginateResponse<GetByCreatorUserIdPaginatedDto>>> GetByCreatorUserId([FromQuery] GetByCreatorUserIdPaginatedRequestDto getByCreatorUserIdPaginatedRequestDto, [FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetByCreatorUserIdPaginatedQuery(getByCreatorUserIdPaginatedRequestDto, pageRequest);
            var result = await Mediator.Send(query, cancellationToken);
            return ReturnResult(result);
        }

        [HttpGet]
        public async Task<IDataResult<PaginateResponse<GetAllPaginatedProductDto>>> GetAllPaginated([FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetAllPaginatedProductQuery(pageRequest);
            var result = await Mediator.Send(query, cancellationToken);
            return ReturnResult(result);
        }

        [HttpGet("GetByTitle")]
        public async Task<IDataResult<PaginateResponse<GetByTitlePaginatedProductDto>>> GetByTitlePaginated([FromQuery] GetByTitlePaginatedProductRequestDto getByTitlePaginatedProductRequestDto,[FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetByTitlePaginatedProductQuery(getByTitlePaginatedProductRequestDto, pageRequest);
            var result = await Mediator.Send(query, cancellationToken);
            return ReturnResult(result);
        }
    }
}
