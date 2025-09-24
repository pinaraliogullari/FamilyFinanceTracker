using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Features.User.Commands.DeleteUser;
using FinancialTrack.Infrastructure.UoW;
using FinancialTrack.Persistence.AbstractRepositories.FinancialRecordRepository;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.DeleteFinancialRecord;

public class DeleteFinancialRecordCommandHandler : IRequestHandler<DeleteFinancialRecordCommandRequest,
    DeleteFinancialRecordCommandResponse>
{
    private readonly IFinancialRecordReadRepository _financialRecordReadRepository;
    private readonly IFinancialRecordWriteRepository _financialRecordWriteRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public DeleteFinancialRecordCommandHandler
    (
        IFinancialRecordReadRepository financialRecordReadRepository,
        IFinancialRecordWriteRepository financialRecordWriteRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _financialRecordReadRepository = financialRecordReadRepository;
        _financialRecordWriteRepository = financialRecordWriteRepository;
        _uow = uow;
    }


    public async Task<DeleteFinancialRecordCommandResponse> Handle(DeleteFinancialRecordCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _financialRecordReadRepository.GetByIdAsync(request.FinancialRecordId);
        if (category == null)
            throw new NotFoundException($"FinancialRecord with id {request.FinancialRecordId} not found");
        _financialRecordWriteRepository.Remove(category);
        await _uow.SaveChangesAsync();
        return new DeleteFinancialRecordCommandResponse()
        {
            FinancialRecordId = request.FinancialRecordId
        };
    }
}