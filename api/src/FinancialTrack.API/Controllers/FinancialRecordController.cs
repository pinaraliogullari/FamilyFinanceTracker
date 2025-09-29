using System.Net;
using FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;
using FinancialTrack.Application.Features.FinancialRecord.Commands.DeleteFinancialRecord;
using FinancialTrack.Application.Features.FinancialRecord.Commands.UpdateFinancialRecord;
using FinancialTrack.Application.Features.FinancialRecord.Queries.GetAllFinancialRecords;
using FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordById;
using FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordsByType;
using FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordsByUserId;
using FinancialTrack.Core.Results;
using FinancialTrack.Domain.Entities.Enums;
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
    public async Task<IApiResult> CreateFinancialRecord([FromBody] CreateFinancialRecordCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleApiResponse(response, httpStatusCode: HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IApiResult> UpdateFinancialRecord([FromBody] UpdateFinancialRecordCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleApiResponse(response);
    }

    [HttpDelete]
    [Route("{financialRecordId}")]
    public async Task<IApiResult> DeleteFinancialRecord([FromRoute] long financialRecordId)
    {
        var response = await _mediator.Send(new DeleteFinancialRecordCommandRequest
            { FinancialRecordId = financialRecordId });
        return HandleApiResponse(response);
    }

    [HttpGet]
    public async Task<IApiResult> GetAllFinancialRecords()
    {
        var response = await _mediator.Send(new GetAllFinancialRecordsQueryRequest());
        return HandleApiResponse(response);
    }

    [HttpGet]
    [Route("record/{recordId}")]
    public async Task<IApiResult> GetRecordById([FromRoute] long recordId)
    {
        var response = await _mediator.Send(new GetFinancialRecordByIdQueryRequest { FinancialRecordId = recordId });
        return HandleApiResponse(response);
    }

    [HttpGet]
    [Route("user/{userId}")]
    public async Task<IApiResult> GetUsersFinancialRecords([FromRoute] long userId)
    {
        var response = await _mediator.Send(new GetFinancialRecordsByUserIdQueryRequest() { UserId = userId });
        return HandleApiResponse(response);
    }

    [HttpGet]
    [Route("type/{recordType}")]
    public async Task<IApiResult> GetFinancialRecordsByType([FromRoute] FinancialRecordType recordType)
    {
        var response = await _mediator.Send(new GetFinancialRecordsByTypeQueryRequest
            { FinancialRecordType = recordType });
        return HandleApiResponse(response);
    }

    [HttpGet]
    [Route("my-records")]
    public async Task<IApiResult> GetMyFinancialRecords()
    {
        var response = await _mediator.Send(new GetFinancialRecordsByUserIdQueryRequest());
        return HandleApiResponse(response);
    }
}