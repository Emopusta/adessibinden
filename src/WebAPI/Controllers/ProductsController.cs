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
        [HttpGet("GetByCreator/{creatorUserId}")]
        public async Task<IDataResult<PaginateResponse<GetByCreatorUserIdPaginatedDto>>> GetByCreatorUserId([FromQuery] PageRequest pageRequest, [FromRoute] int creatorUserId)
        {
            var query = new GetByCreatorUserIdPaginatedQuery() { CreatorUserId = creatorUserId, PageRequest = pageRequest };
            var result = await Mediator.Send(query);
            return ReturnResult(result);
        }
        [HttpGet]
        public async Task<IDataResult<PaginateResponse<GetAllPaginatedProductDto>>> GetAllPaginated([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllPaginatedProductQuery() { PageRequest = pageRequest };
            var result = await Mediator.Send(query);
            return ReturnResult(result);
        }
        [HttpGet("GetByTitle")]
        public async Task<IDataResult<PaginateResponse<GetByTitlePaginatedProductDto>>> GetByTitlePaginated([FromQuery] PageRequest pageRequest, string productTitleToSearch)
        {
            var query = new GetByTitlePaginatedProductQuery() { PageRequest = pageRequest , ProductTitleToSearch = productTitleToSearch};
            var result = await Mediator.Send(query);
            return ReturnResult(result);
        }
    }
}
