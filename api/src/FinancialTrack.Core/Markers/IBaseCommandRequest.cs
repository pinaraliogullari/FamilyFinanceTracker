using MediatR;

namespace FinancialTrack.Core.Markers;

public interface IBaseCommandRequest<TResponse>:IRequest<TResponse>
{
    
}