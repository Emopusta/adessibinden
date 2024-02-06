using Core.Application.Responses;

namespace Application.Services.ProductService.Responses;
public class DeletedProductServiceResponse : IResponse
{
    public int ProductId { get; set; }
}
