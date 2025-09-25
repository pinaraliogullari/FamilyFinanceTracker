using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;

public class CreateFinancialRecordCommandHandler : IRequestHandler<CreateFinancialRecordCommandRequest,
    CreateFinancialRecordCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public CreateFinancialRecordCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<CreateFinancialRecordCommandResponse> Handle(
        CreateFinancialRecordCommandRequest request,
        CancellationToken cancellationToken)
    {
        var financialRecord = new Domain.Entities.FinancialRecord()
        {
            Amount = request.Amount,
            Description = request.Description,
            UserId = request.UserId,
            CategoryId = request.CategoryId
        };
        await _uow.GetWriteRepository<Domain.Entities.FinancialRecord>().AddAsync(financialRecord);
        return new CreateFinancialRecordCommandResponse
        {
            FinancialRecordId = financialRecord.Id,
        };
    }
}