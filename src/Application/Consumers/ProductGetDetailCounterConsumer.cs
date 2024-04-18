using Core.Application.GenericRepository;
using Core.DataAccess.UoW;
using Core.EventBus.Attributes;
using Core.EventBus.EmopCap;
using Core.EventBus.Messages;
using Domain.Models;

namespace Application.Consumers;
public class ProductGetDetailCounterConsumer : IEmopCapConsumer
{
    private readonly IGenericRepository<ProductInteractionCount> _interactionCountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductGetDetailCounterConsumer(IGenericRepository<ProductInteractionCount> interactionCountRepository, IUnitOfWork unitOfWork)
    {
        _interactionCountRepository = interactionCountRepository;
        _unitOfWork = unitOfWork;
    }

    [CustomCapSubscribe(typeof(PhoneProductDetailsMessage))]
    public async Task ConsumerAsync(PhoneProductDetailsMessage message, CancellationToken cancellationToken)
    {
        var interaction = await _interactionCountRepository.GetAsync(p => p.ProductId == message.ProductId, cancellationToken: cancellationToken);
        interaction!.Count++;

        await _interactionCountRepository.UpdateAsync(interaction);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}