using Application.Features.Products.Commands.Create;
using Core.Application.GenericRepository;
using Core.Application.Pipelines;
using Core.DataAccess.Repositories;
using Domain.Models;

namespace Application.Features.PhoneProducts.Commands.Create;

public class CreatePhoneProductCommandHandler : ICommandRequestHandler<CreatePhoneProductCommand, CreatedPhoneProductResponse>
{
    private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreatePhoneProductCommandHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork)
    {
        _phoneProductRepository = phoneProductRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreatedPhoneProductResponse> Handle(CreatePhoneProductCommand request, CancellationToken cancellationToken)
    {
        // Todo: refactor CreateProduct Parameter
        var createdProduct = await CreateProduct(request.CreatePhoneProductDto.CreatorUserId, request.CreatePhoneProductDto.ProductCategoryId, request.CreatePhoneProductDto.Description, request.CreatePhoneProductDto.Title, cancellationToken);

        var phone = new PhoneProduct()
        {
            ProductId = createdProduct.Id,
            ColorId = request.CreatePhoneProductDto.ColorId,
            ModelId = request.CreatePhoneProductDto.ModelId,
            InternalMemoryId = request.CreatePhoneProductDto.InternalMemoryId,
            RAMId = request.CreatePhoneProductDto.RAMId,
            UsageStatus = request.CreatePhoneProductDto.UsageStatus,
            Price = request.CreatePhoneProductDto.Price,
        };

        var addedPhone = await _phoneProductRepository.AddAsync(phone);

        var response = new CreatedPhoneProductResponse()
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

    private async Task<CreatedProductResponse> CreateProduct(int creatorUserId, int productCategoryId, string description, string title, CancellationToken cancellationToken)
    {
        Product product = new()
        {
            Description = description,
            Title = title,
            CreatorUserId = creatorUserId,
            ProductCategoryId = productCategoryId
        };

        Product addedProduct = await _productRepository.AddAsync(product);
        await _unitOfWork.SaveAsync(cancellationToken);

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
}
