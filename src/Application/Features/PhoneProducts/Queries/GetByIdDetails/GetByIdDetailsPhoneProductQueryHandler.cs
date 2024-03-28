using AutoMapper;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.EventBus.RabbitMQ;
using Domain.Models;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PhoneProducts.Queries.GetByIdDetails;

public class GetByIdDetailsPhoneProductQueryHandler : IQueryRequestHandler<GetByIdDetailsPhoneProductQuery, GetByIdDetailsPhoneProductResponse>
{
    private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
    private readonly IMapper _mapper;
    private readonly ICapPublisher _capPublisher;

    public GetByIdDetailsPhoneProductQueryHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IMapper mapper, ICapPublisher capPublisher)
    {
        _phoneProductRepository = phoneProductRepository;
        _mapper = mapper;
        _capPublisher = capPublisher;
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

        await _capPublisher.PublishAsync("phone_product_details_queue_cap", contentObj: new { ProductId = phoneProduct!.ProductId }, cancellationToken: cancellationToken);

        return result;
    }
}
