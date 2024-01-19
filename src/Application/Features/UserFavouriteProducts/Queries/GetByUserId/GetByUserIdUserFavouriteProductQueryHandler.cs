﻿using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.Application.Responses;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFavouriteProducts.Queries.GetByUserId
{
    public class GetByUserIdUserFavouriteProductQueryHandler : IQueryRequestHandler<GetByUserIdUserFavouriteProductQuery, ListResponse<GetByUserIdUserFavouriteProductResponse>>
    {
        private readonly IGenericRepository<UserFavouriteProduct> _userFavouriteProductRepository;
        private readonly IMapper _mapper;

        public GetByUserIdUserFavouriteProductQueryHandler(IGenericRepository<UserFavouriteProduct> userFavouriteProductRepository, IMapper mapper)
        {
            _userFavouriteProductRepository = userFavouriteProductRepository;
            _mapper = mapper;
        }

        public async Task<ListResponse<GetByUserIdUserFavouriteProductResponse>> Handle(GetByUserIdUserFavouriteProductQuery request, CancellationToken cancellationToken)
        {

            var userFavouriteProducts = await _userFavouriteProductRepository.GetListAsync(predicate: p => p.UserId == request.UserId,
                include: i => i.Include(i => i.Product)); 

            var response = _mapper.Map<ListResponse<GetByUserIdUserFavouriteProductResponse>>(userFavouriteProducts);

            return response;
        }
    }
}
