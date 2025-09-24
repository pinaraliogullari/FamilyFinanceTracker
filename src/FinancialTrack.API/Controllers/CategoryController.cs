using FinancialTrack.Application.Features.Category.Commands.CreateCategory;
using FinancialTrack.Application.Features.Category.Commands.DeleteCategory;
using FinancialTrack.Application.Features.Category.Queries.GetAllCategories;
using FinancialTrack.Application.Features.Category.Queries.GetCategoriesByType;
using FinancialTrack.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : BaseController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("create-category")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    [Route("get-categories")]
    public async Task<IActionResult> GetCategories()
    {
        var response = await _mediator.Send(new GetAllCategoriesQueryRequest());
        return Ok(response);
    }

    [HttpGet]
    [Route("type/{recordType}")]
    public async Task<IActionResult> GetCategoriesByRecordType(FinancialRecordType recordType)
    {
        var response = await _mediator.Send(new GetCategoriesByTypeQueryRequest { RecordType = recordType });
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("delete-category/{categoryId}")]
    public async Task<IActionResult> DeleteCategory(long categoryId)
    {
        var response = await _mediator.Send(new DeleteCategoryCommandRequest{ CategoryId = categoryId });
        return Ok(response);
    }
}