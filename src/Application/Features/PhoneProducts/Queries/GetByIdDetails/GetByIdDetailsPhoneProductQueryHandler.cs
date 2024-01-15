﻿using Application.Features.PhoneProducts.Rules;
using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails
{
    public class GetByIdDetailsPhoneProductQueryHandler : IRequestHandler<GetByIdDetailsPhoneProductQuery, GetByIdDetailsPhoneProductResponse>
    {
        private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
        private readonly PhoneProductBusinessRules _phoneProductBusinessRules;
        private readonly IMapper _mapper;

        public GetByIdDetailsPhoneProductQueryHandler(IGenericRepository<PhoneProduct> phoneProductRepository, PhoneProductBusinessRules phoneProductBusinessRules, IMapper mapper)
        {
            _phoneProductRepository = phoneProductRepository;
            _phoneProductBusinessRules = phoneProductBusinessRules;
            _mapper = mapper;
        }

        public async Task<GetByIdDetailsPhoneProductResponse> Handle(GetByIdDetailsPhoneProductQuery request, CancellationToken cancellationToken)
        {
            var phoneProduct = await _phoneProductRepository.GetAsync(p => p.ProductId == request.ProductId,
                include: i => i
                .Include(p => p.Color)
                .Include(p => p.RAM)
                .Include(p => p.Product)
                .Include(p => p.Product.CreatorUser)
                .Include(p => p.InternalMemory)
                .Include(p => p.Model)          
                );

            await _phoneProductBusinessRules.PhoneProductMustExist(phoneProduct);

            var result = _mapper.Map<GetByIdDetailsPhoneProductResponse>(phoneProduct);

            return result;
        }
    }
}
