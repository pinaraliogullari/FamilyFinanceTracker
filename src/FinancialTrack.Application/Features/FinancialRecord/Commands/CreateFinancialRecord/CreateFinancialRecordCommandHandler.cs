using FinancialTrack.Application.Wrappers;
using FinancialTrack.Infrastructure.UoW;
using FinancialTrack.Persistence.AbstractRepositories.FinancialRecordRepository;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;

public class CreateFinancialRecordCommandHandler : IRequestHandler<CreateFinancialRecordCommandRequest,
    ApiResult<CreateFinancialRecordCommandResponse>>
{
    private readonly IFinancialRecordWriteRepository _financialRecordWriteRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;


    public CreateFinancialRecordCommandHandler
    (
        IFinancialRecordWriteRepository financialRecordWriteRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _financialRecordWriteRepository = financialRecordWriteRepository;
        _uow = uow;
    }

    public async Task<ApiResult<CreateFinancialRecordCommandResponse>> Handle(
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
        await _financialRecordWriteRepository.AddAsync(financialRecord);
        await _uow.SaveChangesAsync();
        var response = new CreateFinancialRecordCommandResponse
        {
            FinancialRecordId = financialRecord.Id,
        };
        return ApiResult<CreateFinancialRecordCommandResponse>.SuccessResult(response);
        

    }
}