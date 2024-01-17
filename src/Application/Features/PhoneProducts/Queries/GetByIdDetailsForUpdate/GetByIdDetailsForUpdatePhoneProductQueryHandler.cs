using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate
{
    public class GetByIdDetailsForUpdatePhoneProductQueryHandler : IRequestHandler<GetByIdDetailsForUpdatePhoneProductQuery, GetByIdDetailsForUpdatePhoneProductResponse>
    {
        private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
        private readonly IMapper _mapper;

        public GetByIdDetailsForUpdatePhoneProductQueryHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IMapper mapper)
        {
            _phoneProductRepository = phoneProductRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdDetailsForUpdatePhoneProductResponse> Handle(GetByIdDetailsForUpdatePhoneProductQuery request, CancellationToken cancellationToken)
        {
            var phoneProduct = await _phoneProductRepository.GetAsync(p => p.ProductId == request.ProductId,
                include: i => i
                .Include(p => p.Color)
                .Include(p => p.RAM)
                .Include(p => p.Product)
                .Include(p => p.Product.CreatorUser)
                .Include(p => p.InternalMemory)
                .Include(p => p.Model)
                .Include(p => p.Model.Brand)
                );

            var result = _mapper.Map<GetByIdDetailsForUpdatePhoneProductResponse>(phoneProduct);

            return result;
        }
    }
}
