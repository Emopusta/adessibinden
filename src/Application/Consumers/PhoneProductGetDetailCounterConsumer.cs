using Core.Application.GenericRepository;
using Core.DataAccess.UoW;
using Domain.Models;
using DotNetCore.CAP;
using System.Text.Json;
using System.Transactions;

namespace Application.Consumers;
public class PhoneProductGetDetailCounterConsumer : ICapSubscribe
{
    private readonly IGenericRepository<InteractionCount> _interactionCountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PhoneProductGetDetailCounterConsumer(IGenericRepository<InteractionCount> interactionCountRepository, IUnitOfWork unitOfWork)
    {
        _interactionCountRepository = interactionCountRepository;
        _unitOfWork = unitOfWork;
    }

    [CapSubscribe("phone_product_details_queue_cap")]
    public async Task ConsumerAsync(JsonElement phoneProduct, CancellationToken cancellationToken)
    {

        using TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled);
        try
        {
            var interaction = await _interactionCountRepository.GetAsync(p => p.Name == "phone_product_details_queue_cap", cancellationToken: cancellationToken);
            interaction!.Count++;
            var result = await _interactionCountRepository.UpdateAsync(interaction);
            await _unitOfWork.SaveAsync(cancellationToken);
            Console.WriteLine(result);
            throw new Exception("Test Exception");
            transactionScope.Complete();
        }
        catch (Exception)
        {
            transactionScope.Dispose();
            throw;
        }
      
        Console.WriteLine(phoneProduct);
    }

}
