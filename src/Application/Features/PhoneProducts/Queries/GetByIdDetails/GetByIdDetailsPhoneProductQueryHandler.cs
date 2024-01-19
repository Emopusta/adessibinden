using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails
{
    public class GetByIdDetailsPhoneProductQueryHandler : IQueryRequestHandler<GetByIdDetailsPhoneProductQuery, GetByIdDetailsPhoneProductResponse>
    {
        private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
        private readonly IMapper _mapper;

        public GetByIdDetailsPhoneProductQueryHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IMapper mapper)
        {
            _phoneProductRepository = phoneProductRepository;
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
                .Include(p => p.Model.Brand)
                );

            var result = _mapper.Map<GetByIdDetailsPhoneProductResponse>(phoneProduct);

            return result;
        }
    }
}
