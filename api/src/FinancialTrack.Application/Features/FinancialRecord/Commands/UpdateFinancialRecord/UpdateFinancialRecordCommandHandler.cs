using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.UpdateFinancialRecord;

public class UpdateFinancialRecordCommandHandler : IRequestHandler<UpdateFinancialRecordCommandRequest,
    UpdateFinancialRecordCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;
    private readonly ICurrentUserService _currentUserService;

    public UpdateFinancialRecordCommandHandler
    (
        IGenericUnitofWork<FinancialTrackDbContext> uow,
        ICurrentUserService currentUserService
    )
    {
        _uow = uow;
        _currentUserService = currentUserService;
    }


    public async Task<UpdateFinancialRecordCommandResponse> Handle(UpdateFinancialRecordCommandRequest request,
        CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.UserId;
        var financialRecord = await _uow.GetReadRepository<Domain.Entities.FinancialRecord>().GetByIdAsync(request.FinancialRecordId);
        if (financialRecord == null)
            throw new NotFoundException($"Financial record with id {request.FinancialRecordId} not found");

        if (financialRecord.UserId != long.Parse(currentUserId))
            throw new UnauthorizedAccessException("You are not authorized to update this financial record.");

        if (request.Amount.HasValue) financialRecord.Amount = request.Amount.Value;
        if (request.CategoryId.HasValue) financialRecord.CategoryId = request.CategoryId.Value;
        if (!string.IsNullOrWhiteSpace(request.Description)) financialRecord.Description = request.Description;
        
        _uow.GetWriteRepository<Domain.Entities.FinancialRecord>().Update(financialRecord);

        return new UpdateFinancialRecordCommandResponse
        {
            FinancialRecordId = financialRecord.Id,
            Amount = financialRecord.Amount,
            CategoryId = financialRecord.CategoryId,
            Description = financialRecord.Description,
            UserId = financialRecord.UserId
        };
    }
}