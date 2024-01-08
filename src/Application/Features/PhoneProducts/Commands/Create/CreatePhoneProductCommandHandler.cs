using Application.Services.ProductService;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProducts.Commands.Create
{
    public class CreatePhoneProductCommandHandler : IRequestHandler<CreatePhoneProductCommand, CreatedPhoneProductResponse>
    {
        private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
        private readonly IProductService _productService;

        public CreatePhoneProductCommandHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IProductService productService)
        {
            _phoneProductRepository = phoneProductRepository;
            _productService = productService;
        }

        public async Task<CreatedPhoneProductResponse> Handle(CreatePhoneProductCommand request, CancellationToken cancellationToken)
        {
            var createdProduct = await _productService.CreateProduct(request.CreatorUserId, request.ProductCategoryId);

            var phone = new PhoneProduct()
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
    }
}
