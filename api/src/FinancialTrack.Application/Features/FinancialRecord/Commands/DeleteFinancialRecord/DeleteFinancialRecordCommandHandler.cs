using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Features.User.Commands.DeleteUser;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.DeleteFinancialRecord;

public class DeleteFinancialRecordCommandHandler : IRequestHandler<DeleteFinancialRecordCommandRequest,
    DeleteFinancialRecordCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;


    public DeleteFinancialRecordCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<DeleteFinancialRecordCommandResponse> Handle(DeleteFinancialRecordCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _uow.GetReadRepository<Domain.Entities.FinancialRecord>()
            .GetByIdAsync(request.FinancialRecordId);
        if (category == null)
            throw new NotFoundException($"FinancialRecord with id {request.FinancialRecordId} not found");
        _uow.GetWriteRepository<Domain.Entities.FinancialRecord>().Remove(category);
        return new DeleteFinancialRecordCommandResponse()
        {
            FinancialRecordId = request.FinancialRecordId
        };
    }
}