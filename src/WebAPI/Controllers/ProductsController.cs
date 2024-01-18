using Application.Features.Products.Queries.GetByCreatorUserIdPaginated;
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
        [HttpGet("get-by-creator/userId={creatorUserId}")]
        public async Task<IDataResult<GetListResponse<GetByCreatorUserIdPaginatedDto>>> GetByCreatorUserId([FromQuery] PageRequest pageRequest, [FromRoute] int creatorUserId)
        {
            var query = new GetByCreatorUserIdPaginatedQuery() { CreatorUserId = creatorUserId, PageRequest = pageRequest };
            var result = await Mediator.Send(query);
            return ReturnResult(result);
        }

        
    }
}
