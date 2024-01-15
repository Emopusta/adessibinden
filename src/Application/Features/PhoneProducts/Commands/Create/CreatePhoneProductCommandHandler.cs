using Application.Services.ProductService;
using Core.Application.GenericRepository;
using Core.CrossCuttingConcerns.Exceptions.Types;
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

            var createdProduct = await _productService.CreateProduct(request.CreatePhoneProductDto.CreatorUserId, request.CreatePhoneProductDto.ProductCategoryId, request.CreatePhoneProductDto.Description, request.CreatePhoneProductDto.Title, cancellationToken);


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
    }
}
