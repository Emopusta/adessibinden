﻿using Application.Features.ProductCategories.Dtos;
using Core.Application.CQRS;
using Core.Application.Responses;

namespace Application.Features.ProductCategories.Queries.GetAllList;
public class GetAllListProductCategoryQuery : IQueryRequest<ListResponse<GetAllListProductCategoryDto>>
{
}
