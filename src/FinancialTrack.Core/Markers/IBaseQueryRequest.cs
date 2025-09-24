using MediatR;

namespace FinancialTrack.Core.Markers;

public interface IBaseQueryRequest<TResponse>:IRequest<TResponse>
{
    
}