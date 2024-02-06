using Core.Application.Pipelines;

namespace Application.Features.UserFavouriteProducts.Commands.Create;

public class CreateUserFavouriteProductCommand : ICommandRequest<CreatedUserFavouriteProductResponse>
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
