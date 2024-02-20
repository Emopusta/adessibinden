using Application.Features.PhoneProducts.Commands.Update;
using Application.Features.PhoneProducts.Queries.GetByIdDetails;
using Application.Features.PhoneProducts.Queries.GetByIdDetailsForUpdate;
using Application.Features.Products.Commands.Update;
using AutoMapper;
using Domain.Models;

namespace Application.Features.PhoneProducts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PhoneProduct, GetByIdDetailsPhoneProductResponse>().ReverseMap();
        CreateMap<PhoneProduct, GetByIdDetailsForUpdatePhoneProductResponse>().ReverseMap();

        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<PhoneProduct, UpdatePhoneProductCommand>().ReverseMap();
        CreateMap<PhoneProduct, UpdatedPhoneProductResponse>().ReverseMap();
    }
}
