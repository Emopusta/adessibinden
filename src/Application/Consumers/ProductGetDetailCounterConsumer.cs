using Core.Application.GenericRepository;
using Core.DataAccess.UoW;
using Domain.Models;
using DotNetCore.CAP;
using Microsoft.VisualBasic;
using System.Text.Json;
using System.Transactions;

namespace Application.Consumers;
public class ProductGetDetailCounterConsumer : ICapSubscribe
{
    private readonly IGenericRepository<ProductInteractionCount> _interactionCountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductGetDetailCounterConsumer(IGenericRepository<ProductInteractionCount> interactionCountRepository, IUnitOfWork unitOfWork)
    {
        _interactionCountRepository = interactionCountRepository;
        _unitOfWork = unitOfWork;
    }

    [CapSubscribe("phone_product_details_queue_cap")]
    public async Task ConsumerAsync(JsonElement param, CancellationToken cancellationToken)
    {
        var productId = param.GetProperty("ProductId").GetInt32();
        
        var interaction = await _interactionCountRepository.GetAsync(p => p.ProductId == productId, cancellationToken: cancellationToken);
        interaction!.Count++;

        await _interactionCountRepository.UpdateAsync(interaction);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}
