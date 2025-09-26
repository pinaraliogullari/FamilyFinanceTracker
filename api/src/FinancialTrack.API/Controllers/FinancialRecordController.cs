using System.Net;
using FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;
using FinancialTrack.Application.Features.FinancialRecord.Commands.DeleteFinancialRecord;
using FinancialTrack.Application.Features.FinancialRecord.Commands.UpdateFinancialRecord;
using FinancialTrack.Application.Features.FinancialRecord.Queries.GetAllFinancialRecords;
using FinancialTrack.Application.Features.FinancialRecord.Queries.GetByIdFinancialRecord;
using FinancialTrack.Application.Features.FinancialRecord.Queries.GetUsersFinancialRecords;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class FinancialRecordController : BaseController
{
    private readonly IMediator _mediator;

    public FinancialRecordController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFinancialRecord([FromBody] CreateFinancialRecordCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleApiResponse(response, httpStatusCode: HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFinancialRecord([FromBody] UpdateFinancialRecordCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleApiResponse(response);
    }

    [HttpDelete]
    [Route("{financialRecordId}")]
    public async Task<IActionResult> DeleteFinancialRecord([FromRoute] long financialRecordId)
    {
        var response = await _mediator.Send(new DeleteFinancialRecordCommandRequest
            { FinancialRecordId = financialRecordId });
        return HandleApiResponse(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFinancialRecords()
    {
        var response = await _mediator.Send(new GetAllFinancialRecordsQueryRequest());
        return HandleApiResponse(response);
    }

    [HttpGet]
    [Route("record/{recordId}")]
    public async Task<IActionResult> GetRecordById([FromRoute] long recordId)
    {
        var response = await _mediator.Send(new GetByIdFinancialRecordQueryRequest { FinancialRecordId = recordId });
        return HandleApiResponse(response);
    }

    [HttpGet]
    [Route("user/{userId}")]
    public async Task<IActionResult> GetUsersFinancialRecords([FromRoute] long userId)
    {
        var response = await _mediator.Send(new GetUsersFinancialRecordQueryRequest { UserId = userId });
        return HandleApiResponse(response);
    }
}