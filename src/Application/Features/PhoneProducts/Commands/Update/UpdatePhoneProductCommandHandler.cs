using Application.Features.Products.Commands.Update;
using AutoMapper;
using Core.Application.CQRS;
using Core.Application.GenericRepository;
using Core.DataAccess.UoW;
using Domain.Models;

namespace Application.Features.PhoneProducts.Commands.Update;

public class UpdatePhoneProductCommandHandler : ICommandRequestHandler<UpdatePhoneProductCommand, UpdatedPhoneProductResponse>
{
    private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePhoneProductCommandHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IMapper mapper, IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork)
    {
        _phoneProductRepository = phoneProductRepository;
        _mapper = mapper;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdatedPhoneProductResponse> Handle(UpdatePhoneProductCommand request, CancellationToken cancellationToken)
    {
        await UpdateProduct(request.ProductId, request.CreatorUserId, request.ProductCategoryId, request.Description, request.Title, cancellationToken);
        
        var phoneProductToUpdate = await _phoneProductRepository.GetAsync(p => p.ProductId == request.ProductId);
        var mappedPhoneProduct = _mapper.Map(request, phoneProductToUpdate);
        var updatedPhoneProduct = await _phoneProductRepository.UpdateAsync(mappedPhoneProduct);
       
        var result = _mapper.Map<UpdatedPhoneProductResponse>(updatedPhoneProduct);
        return result;
    }

    private async Task<UpdatedProductResponse> UpdateProduct(int productId, int creatorUserId, int productCategoryId, string description, string title, CancellationToken cancellationToken)
    {
        var productToUpdate = await _productRepository.GetAsync(p => p.Id == productId);

        UpdateProductDto product = new()
        {
            Id = productId,
            Description = description,
            Title = title,
            CreatorUserId = creatorUserId,
            ProductCategoryId = productCategoryId
        };
        var mappedProduct = _mapper.Map(product, productToUpdate);

        var updatedProduct = await _productRepository.UpdateAsync(mappedProduct);
        await _unitOfWork.SaveAsync(cancellationToken);

        UpdatedProductResponse response = new()
        {
            Id = updatedProduct.Id,
            Description = updatedProduct.Description,
            Title = updatedProduct.Title,
            CreatorUserId = updatedProduct.CreatorUserId,
            ProductCategoryId = updatedProduct.ProductCategoryId
        };
        return response;
    }
}
