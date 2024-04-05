using Application.Features.Products.Commands.Create;
using Application.Features.Products.Dtos;
using Core.Application.CQRS;
using Core.Application.GenericRepository;
using Core.DataAccess.UoW;
using Domain.Models;

namespace Application.Features.PhoneProducts.Commands.Create;

public class CreatePhoneProductCommandHandler : ICommandRequestHandler<CreatePhoneProductCommand, CreatedPhoneProductResponse>
{
    private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<ProductInteractionCount> _interactionCountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePhoneProductCommandHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IGenericRepository<Product> productRepository, IGenericRepository<ProductInteractionCount> interactionCountRepository, IUnitOfWork unitOfWork)
    {
        _phoneProductRepository = phoneProductRepository;
        _productRepository = productRepository;
        _interactionCountRepository = interactionCountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatedPhoneProductResponse> Handle(CreatePhoneProductCommand request, CancellationToken cancellationToken)
    {
        CreateProductDto productToCreate = new() { 
            CreatorUserId = request.CreatorUserId,
            Description = request.Description,
            ProductCategoryId = request.ProductCategoryId,
            Title = request.Title
        };
        var createdProduct = await createProduct(productToCreate, cancellationToken);

        PhoneProduct phone = new()
        {
            ProductId = createdProduct.Id,
            ColorId = request.ColorId,
            ModelId = request.ModelId,
            InternalMemoryId = request.InternalMemoryId,
            RAMId = request.RAMId,
            UsageStatus = request.UsageStatus,
            Price = request.Price,
        };

        var addedPhone = await _phoneProductRepository.AddAsync(phone);

        CreatedPhoneProductResponse response = new()
        {
            ProductId = createdProduct.Id,
            CreatorUserId = createdProduct.CreatorUserId, 
            ProductCategoryId = createdProduct.ProductCategoryId,
            ColorId = addedPhone.ColorId,
            ModelId = addedPhone.ModelId,
            InternalMemoryId = addedPhone.InternalMemoryId,
            RAMId = addedPhone.RAMId,
            UsageStatus = addedPhone.UsageStatus,
            Price = addedPhone.Price,
        };

        return response;
    }

    private async Task<CreatedProductResponse> createProduct(CreateProductDto createProductDto, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Description = createProductDto.Description,
            Title = createProductDto.Title,
            CreatorUserId = createProductDto.CreatorUserId,
            ProductCategoryId = createProductDto.ProductCategoryId
        };

        var addedProduct = await _productRepository.AddAsync(product);
        await _unitOfWork.SaveAsync(cancellationToken);

        await CreateDefaultProductInteractionCount(addedProduct.Id);

        CreatedProductResponse response = new()
        {
            Id = addedProduct.Id,
            Description = addedProduct.Description,
            Title = addedProduct.Title,
            CreatorUserId = addedProduct.CreatorUserId,
            ProductCategoryId = addedProduct.ProductCategoryId
        };
        return response;
    }

    private async Task CreateDefaultProductInteractionCount(int productId)
    {
        var newInteraction = new ProductInteractionCount()
        {
            Count = 0,
            ProductId = productId,
        };

        await _interactionCountRepository.AddAsync(newInteraction);
    }
}
