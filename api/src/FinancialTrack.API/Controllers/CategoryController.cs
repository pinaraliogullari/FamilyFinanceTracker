using System.Net;
using FinancialTrack.Application.Features.Category.Commands.CreateCategory;
using FinancialTrack.Application.Features.Category.Commands.DeleteCategory;
using FinancialTrack.Application.Features.Category.Queries.GetAllCategories;
using FinancialTrack.Application.Features.Category.Queries.GetCategoriesByType;
using FinancialTrack.Core.Results;
using FinancialTrack.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class CategoryController : BaseController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IApiResult> CreateCategory([FromBody]CreateCategoryCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleApiResponse(response,httpStatusCode:HttpStatusCode.Created);
    }

    [HttpGet]
    public async Task<IApiResult> GetCategories()
    {
        var response = await _mediator.Send(new GetAllCategoriesQueryRequest());
        return HandleApiResponse(response);
    }

    [HttpGet]
    [Route("type/{recordType}")]
    public async Task<IApiResult> GetCategoriesByRecordType([FromRoute]FinancialRecordType recordType)
    {
        var response = await _mediator.Send(new GetCategoriesByTypeQueryRequest { RecordType = recordType });
        return HandleApiResponse(response);
    }
    
    [HttpDelete]
    [Route("{categoryId}")]
    public async Task<IApiResult> DeleteCategory([FromRoute]long categoryId)
    {
        var response = await _mediator.Send(new DeleteCategoryCommandRequest{ CategoryId = categoryId });
        return HandleApiResponse(response);
    }
}