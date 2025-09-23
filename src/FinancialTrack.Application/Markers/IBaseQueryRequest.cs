using MediatR;

namespace FinancialTrack.Application.Markers;

public interface IBaseQueryRequest<TResponse>:IRequest<TResponse>
{
    
}