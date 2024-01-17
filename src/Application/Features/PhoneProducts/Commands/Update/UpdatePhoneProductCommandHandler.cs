using AutoMapper;
using Core.Application.GenericRepository;
using Domain.Models;
using MediatR;

namespace Application.Features.PhoneProducts.Commands.Update
{
    public class UpdatePhoneProductCommandHandler : IRequestHandler<UpdatePhoneProductCommand, UpdatedPhoneProductResponse>
    {
        private readonly IGenericRepository<PhoneProduct> _phoneProductRepository;
        private readonly IMapper _mapper;

        public UpdatePhoneProductCommandHandler(IGenericRepository<PhoneProduct> phoneProductRepository, IMapper mapper)
        {
            _phoneProductRepository = phoneProductRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedPhoneProductResponse> Handle(UpdatePhoneProductCommand request, CancellationToken cancellationToken)
        {
            var phoneProductToUpdate = await _phoneProductRepository.GetAsync(p => p.ProductId == request.UpdatePhoneProductDto.ProductId);

            var mappedPhoneProduct = _mapper.Map(request.UpdatePhoneProductDto, phoneProductToUpdate);

            var updatedPhoneProduct = await _phoneProductRepository.UpdateAsync(mappedPhoneProduct);

            var result = _mapper.Map<UpdatedPhoneProductResponse>(updatedPhoneProduct);
            
            return result;
        }
    }
}
