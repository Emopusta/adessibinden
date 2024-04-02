using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.EventBus.Messages;
using Core.EventBus.Extensions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails;

public class GetByIdDetailsPhoneProductQueryHandler : IQueryRequestHandler<GetByIdDetailsPhoneProductQuery, GetByIdDetailsPhoneProductResponse>
{
    private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
    private readonly IMapper _mapper;
    private readonly ICapAdapter _capAdapter;

    public GetByIdDetailsPhoneProductQueryHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IMapper mapper, ICapAdapter capAdapter)
    {
        _phoneProductRepository = phoneProductRepository;
        _mapper = mapper;
        _capAdapter = capAdapter;
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
            .Include(p => p.Product.ProductInteractionCount)
            );

        var result = _mapper.Map<GetByIdDetailsPhoneProductResponse>(phoneProduct);

        await _capAdapter.PublishAsync(new PhoneProductDetailsMessage { ProductId = phoneProduct.ProductId }, cancellationToken: cancellationToken);

        return result;
    }
}
