using Application.Features.PhoneProducts.Rules;
using Application.Services.ProductService;
using Application.Services.UserFavouriteProductService;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProducts.Commands.Delete
{
    public class DeletePhoneProductCommandHandler : IRequestHandler<DeletePhoneProductCommand, DeletedPhoneProductResponse>
    {
        private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
        private readonly IProductService _productService;
        private readonly IUserFavouriteProductService _userFavouriteProductService;
        private readonly PhoneProductBusinessRules _phoneProductBusinessRules;

        public DeletePhoneProductCommandHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IProductService productService, IUserFavouriteProductService userFavouriteProductService, PhoneProductBusinessRules phoneProductBusinessRules)
        {
            _phoneProductRepository = phoneProductRepository;
            _productService = productService;
            _userFavouriteProductService = userFavouriteProductService;
            _phoneProductBusinessRules = phoneProductBusinessRules;
        }

        public async Task<DeletedPhoneProductResponse> Handle(DeletePhoneProductCommand request, CancellationToken cancellationToken)
        {
            var phoneProductToDelete = await _phoneProductRepository.GetAsync(p => p.ProductId == request.ProductId);

            await _phoneProductBusinessRules.PhoneProductMustExist(phoneProductToDelete);

            var deletedPhoneProduct = await _phoneProductRepository.DeleteAsync(phoneProductToDelete);
            await _productService.DeleteProduct(phoneProductToDelete.ProductId);
            await _userFavouriteProductService.DeleteFavouritesByProduct(phoneProductToDelete.ProductId);

            var response = new DeletedPhoneProductResponse()
            {
                ProductId = phoneProductToDelete.ProductId
            };

            return response;
        }
    }
}
