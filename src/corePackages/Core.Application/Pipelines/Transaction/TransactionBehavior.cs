using Core.DataAccess.Repositories;
using MediatR;
using System.Transactions;

namespace Core.Application.Pipelines.Transaction
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommandRequest<TResponse>
    {

        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            using TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled);
            TResponse response;
            try
            {
                response = await next();
                await _unitOfWork.SaveAsync(cancellationToken);
                transactionScope.Complete();
            }
            catch (Exception)
            {
                transactionScope.Dispose();
                throw;
            }

            return response;
        }
    }
}
