using FinancialTrack.Core.Context;
using FinancialTrack.Core.Markers;
using FinancialTrack.Core.UoW;
using MediatR;

namespace FinancialTrack.Core.Behaviors;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommandRequest<TResponse>
{
    private readonly IGenericUnitofWork<BaseDbContext> _uow;

    public TransactionBehavior(IGenericUnitofWork<BaseDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        await _uow.BeginTransactionAsync(cancellationToken);
        try
        {
            var response= await next();
            await _uow.SaveChangesAsync(cancellationToken);
            await _uow.CommitAsync(cancellationToken);
            return response;
        }
        catch (Exception e)
        {
            await _uow.RollbackAsync(cancellationToken);
            throw;
        }

    }
}