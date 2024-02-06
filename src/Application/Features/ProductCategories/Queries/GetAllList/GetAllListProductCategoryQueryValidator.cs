using Application.Features.ProductCategories.Constants;
using Core.Application.GenericRepository;
using Domain.Models;
using FluentValidation;

namespace Application.Features.ProductCategories.Queries.GetAllList;

public class GetAllListProductCategoryQueryValidator : AbstractValidator<GetAllListProductCategoryQuery>
{
    private readonly IGenericRepository<ProductCategory> _productCategoryRepository;
    public GetAllListProductCategoryQueryValidator(IGenericRepository<ProductCategory> productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;

        RuleFor(p => p)
            .MustAsync(ProductCategoriesMustExist).WithMessage(ProductCategoryBusinessMessages.ProductCategoryMustExist);
    }

    private async Task<bool> ProductCategoriesMustExist(object _, CancellationToken cancellationToken)
    {
        return await _productCategoryRepository.AnyAsync();
    }
}
